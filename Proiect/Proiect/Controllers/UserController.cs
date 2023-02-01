using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.Enums;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersWithOrders()
        {
            return Ok( await _userService.GetAllUsersWithOrders() );
        }

        [HttpPost, Authorize(Roles = "Admin")]
        // This method will only be used by an admin(if a normal user has any problems), as a normal User has register 
        public async Task<ActionResult<List<User>>> AddUser(UserRequestDTO NewUser)
        {
            await _userService.AddUser(NewUser);
            return Ok(await _userService.GetAllUsers());
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
