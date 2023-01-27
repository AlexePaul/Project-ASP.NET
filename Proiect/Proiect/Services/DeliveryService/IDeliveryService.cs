using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Services.DeliveryService
{
    public interface IDeliveryService
    {
        public Task<bool> AddDelivery(DeliveryRequestDTO delivery);
        public Task<List<Delivery>> GetAllDeliveries();
    }
}
