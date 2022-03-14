using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Context;
using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        private readonly MealOrderingDbContext _context;

        public UserService(IMapper mapper, MealOrderingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var dbUser = await _context.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser != null)
            {
                throw new Exception("Kullanıcı Mevcut");
            }
            dbUser = _mapper.Map<User>(user);
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
    }
}
