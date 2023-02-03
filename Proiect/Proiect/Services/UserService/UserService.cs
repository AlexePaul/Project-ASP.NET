using Proiect.Models;
using AutoMapper;
using Proiect.Repos.UserRepo;
using Proiect.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Proiect.Helpers.Utils;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Proiect.Models.Enums;
using Proiect.Repos.UnitOfWork;

namespace Proiect.Services.UserService
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _JwtUtils;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _JwtUtils = jwtUtils;
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _unitOfWork._userRepo.GetAll();
            List<UserDTO> result = _mapper.Map<List<UserDTO>>(users);

            return result;
        }

        public async Task<List<UserOrderDTO>> GetAllUsersWithOrders()
        {
            List<UserOrderDTO> usrs = _mapper.Map<List<UserOrderDTO>>(await _unitOfWork._userRepo.GetAllUsersWithOrders());
            return usrs;       
        }
        public async Task<User> AddUser(UserRequestDTO NewUser)
        {
            var newUser = _mapper.Map<User>(NewUser);
            newUser.Id = new Guid();
            newUser.role = Role.User;
            await _unitOfWork._userRepo.CreateAsync(newUser);
            await _unitOfWork._userRepo.SaveAsync();
            return newUser;
        }
        public async Task<bool> RemoveUser(Guid Id)
        {
            var usr = await _unitOfWork._userRepo.FindByIdAsync(Id);
            if (usr != null)
            {
                _unitOfWork._userRepo.Delete(usr);
                await _unitOfWork._userRepo.SaveAsync();
                return true;
            }
            else
            { return false; }
        }
        public async Task<bool> EditUser(Guid Id, UserRequestDTO UpdatedUser)
        {
            var usr = await _unitOfWork._userRepo.FindByIdAsync(Id);
            if (usr != null)
            {
                usr.Adress = UpdatedUser.Adress;
                usr.PhoneNumber = UpdatedUser.PhoneNumber;
                usr.BirthDate = UpdatedUser.BirthDate;
                usr.FirstName = UpdatedUser.FirstName;
                usr.LastName = UpdatedUser.LastName;
                usr.Email = UpdatedUser.Email;
                _unitOfWork._userRepo.Update(usr);
                await _unitOfWork._userRepo.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Auth(UserLogInDTO request)
        {
            var usr = _unitOfWork._userRepo.FindByEmail(request.Email);
            if(usr != null && BCryptNet.Verify(request.Password, usr.Password))
            {
                return _JwtUtils.GenerateJwtToken(usr);
            }
            else
            {
                return null;
            }
        }
        public  User PromoteAdmin(Guid Id)
        {
            User usr = _unitOfWork._userRepo.FindById(Id);
            if (usr != null)
            {
                usr.role = Role.Admin;
                _unitOfWork._userRepo.Update(usr);
                _unitOfWork._userRepo.SaveAsync();
                return usr;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserById(Guid Id)
        {
            var users = await _unitOfWork._userRepo.GetAll();
            return users.FirstOrDefault(usr => usr.Id == Id);
        }
    }
}
