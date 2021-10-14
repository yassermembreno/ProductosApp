using Domain.Enums.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventories
{
    public class InventorySummary
    {        
        public DateTime Date { get; set; }
        public OrderType Type { get; set; }
        public int Unit { get; set; }
        public decimal UnitCost { get; set; }
        public decimal FinalInventory { get; set; }
        public decimal SalesCost { get; set; }
    }
}
