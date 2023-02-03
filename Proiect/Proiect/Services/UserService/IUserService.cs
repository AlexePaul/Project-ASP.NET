using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        public Task<User> GetUserById(Guid id);
        Task<List<UserDTO>> GetAllUsers();
        Task<List<UserOrderDTO>> GetAllUsersWithOrders();
        public Task<User> AddUser(UserRequestDTO NewUser);

        public User PromoteAdmin(Guid Id);

        public Task<bool> RemoveUser(Guid Id);

        public Task<bool> EditUser(Guid Id, UserRequestDTO NewUser);

        public string Auth(UserLogInDTO request);
    }
}
