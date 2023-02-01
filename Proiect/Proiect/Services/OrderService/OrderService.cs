using Proiect.Models;
using Proiect.Repos.OrderRepo;
using Proiect.Models.DTOs;
using Proiect.Repos.OrderContainsRepo;
using Proiect.Repos.DeliveryRepo;
using Proiect.Repos.FoodRepo;
using Proiect.Repos.UnitOfWork;

namespace Proiect.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Order>> GetAllOrdersByAnUser(Guid Id)
        {
            List<Order> orders = await _unitOfWork._orderRepo.GetAll();
            orders = (List<Order>)orders.Where(o => o.UserId == Id).ToList();
            return orders;
        }
        public async Task<bool> PlaceOrder(User _user, List<FoodRequestOrderDTO> cart, string _adress)
        {
            var NewOrder = new Order();
            var UsingDelivery = await _unitOfWork._deliveryRepo.GetDelivery();
            if (UsingDelivery == null)
                return false;
            NewOrder.Adress = _adress;
            NewOrder.UserId = _user.Id;
            NewOrder.DeliveryId = UsingDelivery.Id;

            _unitOfWork._orderRepo.CreateAsync(NewOrder);
            await _unitOfWork._orderRepo.SaveAsync();
            for (int i = 0; i < cart.Count; i++)
            {
                var NewOrderContains = new OrderContains();
                NewOrderContains.OrderId = NewOrder.Id;
                NewOrderContains.FoodId = cart[i].Id;
                NewOrderContains.amount = cart[i].count;
                await _unitOfWork._orderContainsRepo.CreateAsync(NewOrderContains);
                await _unitOfWork._orderContainsRepo.SaveAsync();
            }
            await _unitOfWork._orderRepo.SaveAsync();
            await _unitOfWork._orderContainsRepo.SaveAsync();
            return true;
        }

        public async Task<Order> UpdateAdress(Guid OrderId, string Adress)
        {
            var OrderToUpdate = _unitOfWork._orderRepo.FindById(OrderId);
            OrderToUpdate.Adress = Adress;
            _unitOfWork._orderRepo.Update(OrderToUpdate);
            await _unitOfWork._orderRepo.SaveAsync();
            return OrderToUpdate;
        }

        public async Task<bool> RemoveOrder(Guid OrderId)
        {
            var ord = await _unitOfWork._orderRepo.FindByIdAsync(OrderId);
            if (ord != null)
            {
                _unitOfWork._orderRepo.Delete(ord);
                await _unitOfWork._orderRepo.SaveAsync();
                return true;
            }
            else
            { return false; }
        }

    }
}
