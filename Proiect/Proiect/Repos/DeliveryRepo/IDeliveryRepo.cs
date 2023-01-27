using Proiect.Repos.BaseRepo;
using Proiect.Models;
namespace Proiect.Repos.DeliveryRepo
{
    public interface IDeliveryRepo : IBaseRepo<Delivery>
    {
        public Task<Delivery> GetDelivery();
    }
}
