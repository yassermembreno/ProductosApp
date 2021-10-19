using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IOrderItemService : IService<OrderItem>
    {
        Order FindById(int orderId);
        Order[] FindByType(OrderType orderType);
        Order[] FindByStatus(OrderStatus status);
    }
}
