using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private static List<User> Users = new List<User>
        {
            new User
            {
                Id = 0x1,
                FirstName= "Test",
                LastName= "Testulescu",
                Email= "Test@Test.com",
                PhoneNumber= "07TEST",
                BirthDate= new DateTime(1995, 11, 25),
                Orders= new List<Order> {}
            },
            new User
            {
                Id = 0x2,
                FirstName= "Test2",
                LastName= "Testulescu2",
                Email= "Test2@Test.com",
                PhoneNumber= "07TEST2",
                BirthDate= new DateTime(1992, 11, 25),
                Orders= new List<Order> {}
            }
        };

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(Users);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(UserRequestDTO NewUser)
        {

            User UserToAdd = new User(NewUser);

            Users.Add(UserToAdd);
            return Ok(Users);
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> RemoveUser(int UserId)
        {
            var user = Users.Find(x => x.Id == UserId);
            if (user == null)
                return NotFound();
            Users.Remove(user);
            return Ok(Users);
        } 
    }
}
