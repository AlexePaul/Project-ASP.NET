﻿using Proiect.Models;
using Proiect.Repos.OrderRepo;
using Proiect.Models.DTOs;
using Proiect.Repos.OrderContainsRepo;
using Proiect.Repos.DeliveryRepo;
using Proiect.Repos.FoodRepo;

namespace Proiect.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public IOrderRepo _OrderRepository;
        public IOrderContainsRepo _OrderContainsRepository;
        public IDeliveryRepo _DeliveryRepo;
        public IFoodRepo _FoodRepo;

        public OrderService(IOrderRepo OrderRepo, IOrderContainsRepo OrderContainsRepo, IDeliveryRepo DeliveryRepo, IFoodRepo FoodRepo)
        {
            _OrderRepository= OrderRepo;
            _OrderContainsRepository= OrderContainsRepo;
            _DeliveryRepo= DeliveryRepo;
            _FoodRepo= FoodRepo;
        }

        public async Task<List<Order>> GetAllOrdersByAnUser(Guid Id)
        {
            List<Order> orders = await _OrderRepository.GetAll();
            return (List<Order>)orders.Where(o => o.User.Id == Id);
        }
        public async Task<bool> PlaceOrder(User _user, List<FoodRequestOrderDTO> cart, string _adress)
        {
            var NewOrder = new Order();
            var UsingDelivery = _DeliveryRepo.GetDelivery();
            if (UsingDelivery == null)
                return false;
            NewOrder.Adress = _adress;
            NewOrder.User = _user;
            NewOrder.delivery = UsingDelivery;
            
            _OrderRepository.CreateAsync(NewOrder);
            for(int i = 0; i < cart.Count; i++)
            {
                var NewOrderContains = new OrderContains();
                NewOrderContains.order = NewOrder;
                NewOrderContains.food = _FoodRepo.FindById(cart[i].Id);
                NewOrderContains.amount = cart[i].count;
                await _OrderContainsRepository.CreateAsync(NewOrderContains);
            }
            return true;
        }
            
    }
}
