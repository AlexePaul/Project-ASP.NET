using AutoMapper;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Repos.DeliveryRepo;
using Proiect.Repos.UnitOfWork;

namespace Proiect.Services.DeliveryService
{
    public class DeliveryService :IDeliveryService
    {
        public readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public DeliveryService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;  
            _mapper= mapper;
        }

        public async Task<bool> AddDelivery(DeliveryRequestDTO delivery)
        {
            var NewDelivery = _mapper.Map<Delivery>(delivery);
            NewDelivery.Id = new Guid();
            await _UnitOfWork._deliveryRepo.CreateAsync(NewDelivery);
            await _UnitOfWork._deliveryRepo.SaveAsync();
            return true;
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        {
            return await _UnitOfWork._deliveryRepo.GetAll();
        }

    }
}
