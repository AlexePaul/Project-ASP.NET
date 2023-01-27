using Microsoft.Identity.Client;
using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;
using Proiect.Repos.UserRepo;

namespace Proiect.Repos.OrderRepo
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(DataContext context) : base(context) 
        {
        }
    }
}
