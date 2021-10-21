using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class OrderItemService : BaseService<OrderItem>, IOrderItemService
    {
        private IOrderItemRepository orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository) : base(orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
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
    }
}
