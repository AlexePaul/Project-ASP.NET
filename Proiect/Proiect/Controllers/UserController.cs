using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Services.UserService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok( await _userService.GetAllUsers() );
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(UserRequestDTO NewUser)
        {
            await _userService.AddUser(NewUser);
            return Ok(await _userService.GetAllUsers());
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> RemoveUser(Guid UserId)
        {
            var ok = await _userService.RemoveUser(UserId);
            if (ok == true)
            {
                return Ok(await _userService.GetAllUsers());
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(Guid UserId, UserRequestDTO NewUser)
        {
            var ok = await _userService.EditUser(UserId, NewUser);
            if (ok == true)
            {
                return Ok(await _userService.GetAllUsers());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
