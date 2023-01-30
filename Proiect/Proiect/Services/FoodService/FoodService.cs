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

        public async Task<List<Food>> GetFoodByRest(Guid RestaurantId)
        {
            List<Food> fds =  await _FoodRepo.GetAll();
            var query =
                from f in fds
                group f by f.RestaurantId into g
                select g;
            foreach(var f in query)
            {
                if(f.Key == RestaurantId)
                {
                    List<Food> final = new List<Food>();
                    foreach(var f2 in f)
                    {
                        final.Add(f2);
                    }
                    return final;
                }
            }
            return fds;
        }

        public async Task<Food> UpdateFood(Guid FoodId, FoodRequestDTO UpdatedFood)
        {
            Food FoodToUpdate = await _FoodRepo.FindByIdAsync(FoodId);
            if (FoodToUpdate == null)
                return null;
            FoodToUpdate.Price = UpdatedFood.Price;
            FoodToUpdate.Quantity = UpdatedFood.Quantity;
            FoodToUpdate.Category = UpdatedFood.Category;
            _FoodRepo.Update(FoodToUpdate);
            await _FoodRepo.SaveAsync();
            return FoodToUpdate;
        }
    }
}
