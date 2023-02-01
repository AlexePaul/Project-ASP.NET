using Proiect.Models;
using Proiect.Repos.BaseRepo;

namespace Proiect.Repos.FoodRepo
{
    public interface IFoodRepo : IBaseRepo<Food>
    {
        public Task<List<Food>> GetAllFoodsWithRest();
    }
}
