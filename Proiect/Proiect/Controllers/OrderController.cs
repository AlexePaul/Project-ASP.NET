using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Services.UserService;
using System.ComponentModel;
using Proiect.Services.UserService;
namespace Proiect.Controllers
{
    public class OrderController
    {
        public readonly IOrderService _OrderService;

        public OrderController(IOrderService service)
        {
            _OrderService = service;
        }
        [HttpGet]
        [Authorize]
        public async List<Order> GetAllOrdersByAnUser(Guid Id)
        {

        }
    }
}
