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

    }
}
