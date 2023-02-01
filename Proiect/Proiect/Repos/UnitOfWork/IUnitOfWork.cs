using Proiect.Repos.DeliveryRepo;
using Proiect.Repos.FoodRepo;
using Proiect.Repos.OrderContainsRepo;
using Proiect.Repos.OrderRepo;
using Proiect.Repos.RestaurantRepo;
using Proiect.Repos.UserRepo;

namespace Proiect.Repos.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IDeliveryRepo _deliveryRepo { get; }
        public IFoodRepo _foodRepo { get; }
        public IOrderContainsRepo _orderContainsRepo { get; }
        public IOrderRepo _orderRepo { get; }
        public IRestaurantRepo _restaurantRepo { get; }
        public IUserRepo _userRepo { get; }
    }
}
