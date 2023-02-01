using Proiect.Models.DTOs;
using Proiect.Models;
using Proiect.Repos.FoodRepo;
using AutoMapper;
using Proiect.Repos.RestaurantRepo;
using System.ComponentModel;
using Proiect.Repos.UnitOfWork;

namespace Proiect.Services.FoodService
{
    public class FoodService : IFoodService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _Mapper;

        public FoodService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<List<Food>> AddFood(Guid RestaurantId, FoodRequestDTO NewFoodDTO)
        {
            Food NewFood = new Food();
            NewFood = _Mapper.Map<Food>(NewFoodDTO);
            NewFood.RestaurantId = RestaurantId;
            NewFood.Restaurant = _unitOfWork._restaurantRepo.FindById(RestaurantId);
            await _unitOfWork._foodRepo.CreateAsync(NewFood);
            await _unitOfWork._foodRepo.SaveAsync();
            return await _unitOfWork._foodRepo.GetAll();
        }

        public async Task<List<Food>> GetFoodByRest(Guid RestaurantId)
        {
            List<Food> fds =  await _unitOfWork._foodRepo.GetAll();
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
            Food FoodToUpdate = await _unitOfWork._foodRepo.FindByIdAsync(FoodId);
            if (FoodToUpdate == null)
                return null;
            FoodToUpdate.Price = UpdatedFood.Price;
            FoodToUpdate.Quantity = UpdatedFood.Quantity;
            FoodToUpdate.Category = UpdatedFood.Category;
            _unitOfWork._foodRepo.Update(FoodToUpdate);
            await _unitOfWork._foodRepo.SaveAsync();
            return FoodToUpdate;
        }

        public async Task<bool> RemoveFood(Guid FoodId)
        {
            var food = await _unitOfWork._foodRepo.FindByIdAsync(FoodId);
            if (food != null)
            {
                _unitOfWork._foodRepo.Delete(food);
                await _unitOfWork._foodRepo.SaveAsync();
                return true;
            }
            else
            { return false; }
        }

        public async Task<List<Food>> GetAllFoodsWithRest()
        {
            return await _unitOfWork._foodRepo.GetAllFoodsWithRest(); 
        }
    }
}
