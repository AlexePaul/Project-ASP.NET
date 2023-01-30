using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Repos.RestaurantRepo;

namespace Proiect.Services.RestaurantSerivce
{
    public class RestaurantService :IRestaurantService
    {
        public readonly IRestaurantRepo _RestaurantRepo;
        public readonly IMapper _Mapper;
        public RestaurantService(IRestaurantRepo RestaurantRepo, IMapper mapper)
        {
            _RestaurantRepo= RestaurantRepo;
            _Mapper= mapper;
        }
        
        public async Task<List<Restaurant>> AddRestaurant(RestaurantRequestDTO NewRestaurant)
        {
            var newRestaurant = _Mapper.Map<Restaurant>(NewRestaurant);
            newRestaurant.Id = new Guid();
            await _RestaurantRepo.CreateAsync(newRestaurant);
            await _RestaurantRepo.SaveAsync();
            return await _RestaurantRepo.GetAll();
        }
    }
}
