using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Services.RestaurantSerivce;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        public readonly IRestaurantService _RestaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _RestaurantService = restaurantService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<List<Restaurant>> AddRestaurant(RestaurantRequestDTO newRestaurant)
        {
            return await _RestaurantService.AddRestaurant(newRestaurant);
        }
    }
}
