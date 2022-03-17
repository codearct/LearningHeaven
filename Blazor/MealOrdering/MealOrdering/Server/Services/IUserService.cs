using MealOrdering.Shared.DTO;
using Shared.DTO;

namespace MealOrdering.Server.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(Guid id);
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task<bool> DeleteUser(Guid id);
        Task<UserLoginResponseDTO> Login(string email, string password);
    }
}