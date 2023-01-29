using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Services.FoodService
{
    public interface IFoodService
    {
        public Task<List<Food>> AddFood(Guid RestaurantId, FoodRequestDTO NewFood);
    }
}
