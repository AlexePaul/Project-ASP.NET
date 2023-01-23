using Proiect.Models;
using AutoMapper;
using Proiect.Repos.UserRepo;
using Proiect.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Proiect.Helpers.Utils;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Proiect.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepo _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _JwtUtils;
        public UserService(IUserRepo userRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _JwtUtils = jwtUtils;
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            List<UserDTO> result = _mapper.Map<List<UserDTO>>(users);

            return result;
        }
        public async Task<User> AddUser(UserRequestDTO NewUser)
        {
            var newUser = _mapper.Map<User>(NewUser);
            newUser.Id = new Guid();
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
            return newUser;
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
        public string Auth(UserLogInDTO request)
        {
            var usr = _userRepository.FindByEmail(request.Email);
            if(usr != null && BCryptNet.Verify(request.Password, usr.Password))
            {
                return _JwtUtils.GenerateJwtToken(usr);
            }
            else
            {
                return null;
            }
        }
    }
}
