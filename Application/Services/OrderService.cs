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
        private IOrderItemRepository orderItemRepository;
        private IItemRepository itemRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IItemRepository itemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.itemRepository = itemRepository;
        }

        public void Create(Order t)
        {
            orderRepository.Create(t);
        }

        public void Create(Order order, OrderItem[] items)
        {
            
            orderRepository.Create(order);

            foreach(OrderItem orderItem in items)
            {
                Item item = orderItem.Item;

                item.Quantity = orderItem.Quantity;
                item.Cost = orderItem.Cost;

                itemRepository.Update(item);
                orderItemRepository.Create(orderItem);
            }
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

        public int GetLastId()
        {
            return orderRepository.GetLastId();
        }

        public int Update(Order t)
        {
            throw new NotImplementedException();
        }
    }
}
