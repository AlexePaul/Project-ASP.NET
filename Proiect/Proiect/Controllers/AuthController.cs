using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Services.UserService;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IUserService _userService;

        public AuthController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRequestDTO request)
        {
            request.Password = BCryptNet.HashPassword(request.Password);
            var usr = await _userService.AddUser(request);
            return Ok(usr);
        }

        [HttpPost("login")]

        public ActionResult<string> Login(UserLogInDTO request)
        {
            var usr = _userService.Auth(request);
            if(usr != null)
            {
                return usr;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("PromoteAdmin")]
        public ActionResult<User> PromoteAdmin(Guid Id) 
        {
            var usr = _userService.PromoteAdmin(Id);
            if (usr !=null)
            {
                return Ok(usr);
            }
            else
            {
                return BadRequest();
            }    
        }
    }
}
