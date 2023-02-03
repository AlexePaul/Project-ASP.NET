using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserRequestDTO, User>();
            CreateMap<DeliveryRequestDTO, Delivery>();
            CreateMap<FoodRequestDTO, Food>();
            CreateMap<RestaurantRequestDTO, Restaurant>();
            CreateMap<User, UserOrderDTO>();
            CreateMap<Order, OrderUserDTO>();
        }
    }
}
