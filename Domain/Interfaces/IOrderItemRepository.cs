using Domain.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem[] FindByProductId(int productId);
        OrderItem[] FindByOrderId(int OrderId);
        OrderItem[] FindByItemId(int itemId);
    }
}
