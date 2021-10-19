using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Inventories;
namespace AppCore.Filter.OrderItems
{
    public class OrderItemSortByOrderDate : IComparer<OrderItem>
    {
        public int Compare(OrderItem x, OrderItem y)
        {
            return x.Order.Date.CompareTo(y.Order.Date);
        }   
    }
}
