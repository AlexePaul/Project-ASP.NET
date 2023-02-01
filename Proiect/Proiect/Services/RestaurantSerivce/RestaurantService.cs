using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Repos.RestaurantRepo;
using Proiect.Repos.UnitOfWork;

namespace Proiect.Services.RestaurantSerivce
{
    public class RestaurantService :IRestaurantService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _Mapper;
        public RestaurantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _Mapper= mapper;
        }
        
        public async Task<List<Restaurant>> AddRestaurant(RestaurantRequestDTO NewRestaurant)
        {
            var newRestaurant = _Mapper.Map<Restaurant>(NewRestaurant);
            newRestaurant.Id = new Guid();
            await _unitOfWork._restaurantRepo.CreateAsync(newRestaurant);
            await _unitOfWork._restaurantRepo.SaveAsync();
            return await _unitOfWork._restaurantRepo.GetAll();
        }
    }
}
