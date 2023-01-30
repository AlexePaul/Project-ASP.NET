using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Services.RestaurantSerivce
{
    public interface IRestaurantService
    {
        public Task<List<Restaurant>> AddRestaurant(RestaurantRequestDTO NewRestaurant);
    }
}
