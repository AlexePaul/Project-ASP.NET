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
    }
}
