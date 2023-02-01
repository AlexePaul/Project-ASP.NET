using Proiect.Repos.DeliveryRepo;
using Proiect.Repos.FoodRepo;
using Proiect.Repos.OrderContainsRepo;
using Proiect.Repos.OrderRepo;
using Proiect.Repos.RestaurantRepo;
using Proiect.Repos.UserRepo;

namespace Proiect.Repos.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDeliveryRepo _deliveryRepo { get; set; }
        public IFoodRepo _foodRepo { get; set; }
        public IOrderContainsRepo _orderContainsRepo { get; set; }
        public IOrderRepo _orderRepo { get; set; }
        public IRestaurantRepo _restaurantRepo { get; set; }
        public IUserRepo _userRepo { get; set; }

        public UnitOfWork(IDeliveryRepo deliveryRepo, IFoodRepo foodRepo, IOrderContainsRepo orderContainsRepo, IOrderRepo orderRepo, IRestaurantRepo restaurantRepo, IUserRepo userRepo)
        {
            _deliveryRepo = deliveryRepo;
            _foodRepo = foodRepo;
            _orderContainsRepo = orderContainsRepo;
            _orderRepo = orderRepo;
            _restaurantRepo = restaurantRepo;
            _userRepo = userRepo;
        }
    }
}
