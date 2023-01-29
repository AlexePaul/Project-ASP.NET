using Proiect.Models.DTOs;
using Proiect.Models;
using Proiect.Repos.FoodRepo;
using AutoMapper;
using Proiect.Repos.RestaurantRepo;

namespace Proiect.Services.FoodService
{
    public class FoodService : IFoodService
    {
        public readonly IFoodRepo _FoodRepo;
        public readonly IMapper _Mapper;
        public readonly IRestaurantRepo _RestaurantRepo;

        public FoodService(IFoodRepo foodRepo, IMapper mapper, IRestaurantRepo restaurantRepo)
        {
            _FoodRepo = foodRepo;
            _Mapper = mapper;
            _RestaurantRepo= restaurantRepo;
        }

        public async Task<List<Food>> AddFood(Guid RestaurantId, FoodRequestDTO NewFoodDTO)
        {
            Food NewFood = new Food();
            NewFood = _Mapper.Map<Food>(NewFoodDTO);
            NewFood.RestaurantId = RestaurantId;
            NewFood.Restaurant = _RestaurantRepo.FindById(RestaurantId);
            await _FoodRepo.CreateAsync(NewFood);
            await _FoodRepo.SaveAsync();
            return await _FoodRepo.GetAll();
        }
    }
}
