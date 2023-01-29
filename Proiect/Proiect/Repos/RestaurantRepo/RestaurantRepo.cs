using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;

namespace Proiect.Repos.RestaurantRepo
{
    public class RestaurantRepo : BaseRepo<Restaurant>, IRestaurantRepo
    {
        public RestaurantRepo(DataContext context) : base(context)
        {
        }
    }
}
