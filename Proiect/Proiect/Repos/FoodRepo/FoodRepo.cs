using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;

namespace Proiect.Repos.FoodRepo
{
    public class FoodRepo : BaseRepo<Food>, IFoodRepo
    {
        public FoodRepo(DataContext context) : base(context) 
        { 
        }
        public async Task<List<Food>> GetAllFoodsWithRest()
        {
            var foods = from f in _context.Foods
                        join r in _context.Restaurants on f.RestaurantId equals r.Id
                        select new Food
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Quantity = f.Quantity,
                            Price = f.Price,
                            RestaurantId = f.RestaurantId,
                            Restaurant = r
                        };
            return new List<Food>(foods);
        }
    }
}
