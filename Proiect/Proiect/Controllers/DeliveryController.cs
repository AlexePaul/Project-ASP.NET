using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Services.DeliveryService;

namespace Proiect.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        public readonly IDeliveryService _DeliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _DeliveryService = deliveryService;
        }

        [HttpPost]
        public Task<bool> AddDelivery(DeliveryRequestDTO Delivery)
        {
            return _DeliveryService.AddDelivery(Delivery);
        }

        [HttpGet]

        public Task<List<Delivery>> GetAllDeliveries()
        {
            return _DeliveryService.GetAllDeliveries();
        }

    }
}
