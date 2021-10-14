using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventories
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Producto p, Item item, Order order)
        {
            Item = item;
            Producto = p;
            Order = order;
        }

    }
}
