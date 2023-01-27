using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;
using Proiect.Repos.OrderRepo;

namespace Proiect.Repos.DeliveryRepo
{
    public class DeliveryRepo : BaseRepo<Delivery>, IDeliveryRepo
    {
        public readonly IOrderRepo _OrderRepo;
        public DeliveryRepo(DataContext context, IOrderRepo orderRepo) : base(context)
        {
            _OrderRepo = orderRepo;
        }

        public async Task<Delivery> GetDelivery()
        {
            List<Delivery> Deliveries = await _table.AsNoTracking().ToListAsync();
            var Orders = await _OrderRepo.GetAll();
            List<Delivery> UsedDeliveries= new List<Delivery>();
            List<Delivery> AvailableDeliveries = new List<Delivery>();

            for (int i = 0; i < Orders.Count(); i++)
                UsedDeliveries.Add(Orders[i].delivery);

            for (int i = 0; i < Deliveries.Count(); i++)
            {
                if (UsedDeliveries.Find(x => Deliveries[i] == x) == null)
                {
                    AvailableDeliveries.Add(Deliveries[i]);
                }
            }

            return Deliveries.FirstOrDefault();
        }
    }
}
