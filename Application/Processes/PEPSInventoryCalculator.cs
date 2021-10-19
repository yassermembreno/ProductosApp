using AppCore.Filter.OrderItems;
using AppCore.Interfaces;
using Domain.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processes
{
    public class PEPSInventoryCalculator : IInventoryCalculator
    {
        public decimal CalculateFinalInventory(Item[] items)
        {
            decimal finalInventory = 0.0M;
            foreach(Item item in items)
            {
                finalInventory += item.Cost * item.Available;
            }

            return finalInventory;
        }

        public decimal CalculateSalesCost(OrderItem[] saleOrderItems)
        {

            if(saleOrderItems == null)
            {
                throw new Exception("Error, orderItems vacio.");
            }

            decimal salesCost = 0M;
            Array.Sort(saleOrderItems, new OrderItemSortByOrderDate());

            foreach(OrderItem orderItem in saleOrderItems)
            {
                salesCost += orderItem.Cost * orderItem.Quantity;
            }

            return salesCost;
        }
    }
}
