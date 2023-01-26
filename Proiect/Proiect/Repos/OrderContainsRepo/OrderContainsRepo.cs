using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;
using Proiect.Repos.UserRepo;

namespace Proiect.Repos.OrderContainsRepo
{
    public class OrderContainsRepo : BaseRepo<OrderContains>, IOrderContainsRepo
    {
        public OrderContainsRepo(DataContext context) : base(context)
        {
        }
    }
}
