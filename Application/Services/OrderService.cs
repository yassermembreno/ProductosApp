using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Create(Order t)
        {
            orderRepository.Create(t);
        }

        public bool Delete(Order t)
        {
            throw new NotImplementedException();
        }

        public Order[] FindAll()
        {
            return orderRepository.FindAll();
        }

        public Order FindById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order[] FindByStatus(OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public Order[] FindByType(OrderType orderType)
        {
            throw new NotImplementedException();
        }

        public int Update(Order t)
        {
            throw new NotImplementedException();
        }
    }
}
