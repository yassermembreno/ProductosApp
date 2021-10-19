using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class OrderItemService : IOrderItemService
    {
        private IOrderItemRepository orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }
        public void Create(OrderItem t)
        {
            orderItemRepository.Create(t);
        }

        public bool Delete(OrderItem t)
        {
            throw new NotImplementedException();
        }

        public OrderItem[] FindAll()
        {
            return orderItemRepository.FindAll();
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

        public int Update(OrderItem t)
        {
            throw new NotImplementedException();
        }
    }
}
