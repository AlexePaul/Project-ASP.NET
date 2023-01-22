using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        public Task AddUser(UserRequestDTO NewUser);

        public Task<bool> RemoveUser(Guid Id);

        public Task<bool> EditUser(Guid Id, UserRequestDTO NewUser);
    }
}
