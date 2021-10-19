using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
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
    }
}
