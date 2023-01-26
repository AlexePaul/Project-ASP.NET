using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;

namespace Proiect.Repos.DeliveryRepo
{
    public class DeliveryRepo : BaseRepo<Delivery>, IDeliveryRepo
    {
        public DeliveryRepo(DataContext context) : base(context)
        {
        }

        public Delivery GetDelivery()
        {
            return _table.FirstOrDefault(x => x.order == null);
        }
    }
}
