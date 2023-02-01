using Proiect.Models;
using Proiect.Models.DTOs;
using System.Runtime.CompilerServices;

namespace Proiect.Services.FoodService
{
    public interface IFoodService
    {
        public Task<List<Food>> AddFood(Guid RestaurantId, FoodRequestDTO NewFood);
        public Task<List<Food>> GetFoodByRest(Guid RestaurantId);
        public Task<Food> UpdateFood(Guid FoodId, FoodRequestDTO UpdatedFood);
        public Task<bool> RemoveFood(Guid FoodId);

        public Task<List<Food>> GetAllFoodsWithRest();
    }
}
