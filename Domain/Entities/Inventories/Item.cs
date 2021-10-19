using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventories
{
    public class Item
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public string Brand { get; set; }
        public string SKU { get; set; }
        public decimal MaximumRetailPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public int Available => Quantity - Sold - Defective;
        public int Defective { get; set; }
        public DateTime ExpirationDate { get; set; }    
    }
}
