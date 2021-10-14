using Domain.Entities.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItem[] FindByItemId(int itemId)
        {
            throw new NotImplementedException();
        }

        public OrderItem[] FindByOrderId(int OrderId)
        {
            throw new NotImplementedException();
        }

        public OrderItem[] FindByProductId(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
