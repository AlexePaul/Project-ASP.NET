using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Repos.DeliveryRepo;

namespace Proiect.Services.DeliveryService
{
    public class DeliveryService :IDeliveryService
    {
        public readonly IDeliveryRepo _DeliveryRepo;
        private readonly IMapper _mapper;
        public DeliveryService(IDeliveryRepo DeliveryRepo, IMapper mapper)
        {
            _DeliveryRepo= DeliveryRepo;  
            _mapper= mapper;
        }

        public async Task<bool> AddDelivery(DeliveryRequestDTO delivery)
        {
            var NewDelivery = _mapper.Map<Delivery>(delivery);
            NewDelivery.Id = new Guid();
            await _DeliveryRepo.CreateAsync(NewDelivery);
            await _DeliveryRepo.SaveAsync();
            return true;
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        {
            return await _DeliveryRepo.GetAll();
        }

    }
}
