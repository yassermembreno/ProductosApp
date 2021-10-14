using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums.Inventories
{
    public enum OrderStatus
    {
        New, 
        Checkout,
        Paid,
        Failed,
        Shipped,
        Delivered,
        Returned,
        Complete
    }
}
