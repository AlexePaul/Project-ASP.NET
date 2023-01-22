using Proiect.Models;
using AutoMapper;
using Proiect.Repos.UserRepo;
using Proiect.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepo _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepo userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            List<UserDTO> result = _mapper.Map<List<UserDTO>>(users);

            return result;
        }
        public async Task AddUser(UserRequestDTO NewUser)
        {
            var newUser = _mapper.Map<User>(NewUser);
            newUser.Id = new Guid();
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }
        public async Task<bool> RemoveUser(Guid Id)
        {
            var usr = await _userRepository.FindByIdAsync(Id);
            if (usr != null)
            {
                _userRepository.Delete(usr);
                await _userRepository.SaveAsync();
                return true;
            }
            else
            { return false; }
        }
        public async Task<bool> EditUser(Guid Id, UserRequestDTO UpdatedUser)
        {
            var usr = await _userRepository.FindByIdAsync(Id);
            if (usr != null)
            {
                usr.Adress = UpdatedUser.Adress;
                usr.PhoneNumber = UpdatedUser.PhoneNumber;
                usr.BirthDate = UpdatedUser.BirthDate;
                usr.FirstName = UpdatedUser.FirstName;
                usr.LastName = UpdatedUser.LastName;
                usr.Email = UpdatedUser.Email;
                _userRepository.Update(usr);
                await _userRepository.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
