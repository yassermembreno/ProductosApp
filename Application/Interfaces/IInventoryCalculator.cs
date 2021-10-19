using Domain.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IInventoryCalculator
    {
        decimal CalculateSalesCost(OrderItem[] saleOrderItems);
        decimal CalculateFinalInventory(Item[] items);
    }
}
