using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IOrderItemService : IService<OrderItem>
    {
        OrderItem[] FindByProductId(int productId);
        OrderItem[] FindByOrderId(int OrderId);
        OrderItem[] FindByItemId(int itemId);
    }
}
