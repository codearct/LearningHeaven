using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Context;
using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.DTO;
using Shared.Utils;

namespace MealOrdering.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly MealOrderingDbContext _context;
        private readonly IConfiguration _configuration;


        public UserService(IMapper mapper, MealOrderingDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var dbUser = await _context.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser != null)
            {
                throw new Exception("Kullanıcı Mevcut");
            }

            dbUser = _mapper.Map<User>(user);
            dbUser.Password = PasswordEncrypter.Encrypt(user.Password);
            await _context.Users.AddAsync(dbUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(dbUser);

        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }

            _context.Users.Remove(user);
            int result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            var user = await _context.Users
                            .Where(u => u.Id == id)
                            .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }
            return user;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _context.Users
                            .Where(u => u.IsActive)
                            .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync();
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            var dbUser = await _context.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser == null)
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }

            _mapper.Map(user, dbUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(dbUser);
        }

        public async Task<UserLoginResponseDTO> Login(string email, string password)
        {
            var encryptedPassword = PasswordEncrypter.Encrypt(password);

            var dbUser = await _context.Users.FirstOrDefaultAsync(i => i.EMailAdress == email && i.Password == encryptedPassword);

            if (dbUser == null)
                throw new Exception("User not found or given information is wrong");

            if (!dbUser.IsActive)
                throw new Exception("User state is Passive!");

            UserLoginResponseDTO userLoginResponse = new UserLoginResponseDTO();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.Now.AddDays(int.Parse(_configuration["JwtExpiryInDays"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName)
            };

            var token = new JwtSecurityToken
            (
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                null,
                expireDate,
                credentials
            );

            userLoginResponse.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            userLoginResponse.User = _mapper.Map<UserDTO>(dbUser);

            return userLoginResponse;
        }
    }
}
