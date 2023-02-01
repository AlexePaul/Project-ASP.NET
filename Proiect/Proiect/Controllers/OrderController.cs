using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Services.OrderService;
using Proiect.Services.UserService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController :ControllerBase
    {
        public readonly IOrderService _OrderService;
        public readonly IUserService _UserService;

        public OrderController(IOrderService service, IUserService service2)
        {
            _OrderService = service;
            _UserService = service2;
        }
        [HttpGet]
        [Authorize]
        public async Task<List<Order>> GetAllOrdersByAnUser(Guid Id)
        {
            return await _OrderService.GetAllOrdersByAnUser(Id);
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> PlaceOrder(Guid Id, List<FoodRequestOrderDTO> Cart, string _adress)
        {
            var _user = await _UserService.GetUserById(Id);
            return await _OrderService.PlaceOrder(_user, Cart, _adress);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<Order> ChangeAdress(Guid OrderId, string Adress) 
        {
            var _Order = await _OrderService.UpdateAdress(OrderId, Adress);
            return _Order;
        }

        [HttpDelete]
        [Authorize]

        public async Task<bool> FinishOrder(Guid OrderId)
        {
            return await _OrderService.RemoveOrder(OrderId);
        }
    }
}
