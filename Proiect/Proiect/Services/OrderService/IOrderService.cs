using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Services.OrderService
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrdersByAnUser(Guid Id);
        public Task<bool> PlaceOrder(User _user, List<FoodRequestOrderDTO> cart, string _adress);
    }
}
