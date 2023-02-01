using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Services.FoodService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public readonly IFoodService _FoodService;

        public FoodController(IFoodService service)
        {
            _FoodService = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<List<Food>> AddFood(Guid RestaurantId, FoodRequestDTO NewFood)
        {
            return await _FoodService.AddFood(RestaurantId, NewFood);
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<List<Food>> GetAllFoodByRestaurant(Guid RestaurantId)
        {
            return await _FoodService.GetFoodByRest(RestaurantId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<Food> UpdateFood(Guid FoodId, FoodRequestDTO UpdatedFood)
        {
            return await _FoodService.UpdateFood(FoodId, UpdatedFood);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> RemoveUser(Guid FoodId)
        {
            var ok = await _FoodService.RemoveFood(FoodId);
            if (ok == true)
            {
                return Ok(await _FoodService.GetAllFoodsWithRest());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
