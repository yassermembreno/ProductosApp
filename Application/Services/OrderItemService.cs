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

        public OrderItem[] FindByItemId(int itemId)
        {
            throw new NotImplementedException();
        }

        public OrderItem[] FindByOrderId(int orderId)
        {
            return orderItemRepository.FindByOrderId(orderId);
        }

        public OrderItem[] FindByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            return orderItemRepository.GetLastId();
        }

        public int Update(OrderItem t)
        {
            throw new NotImplementedException();
        }
    }
}
