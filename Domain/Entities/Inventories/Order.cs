using Domain.Enums.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventories
{
    public class Order
    {
        public int Id { get; set; }
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax => Subtotal * 0.15M;// TODO Settings
        public decimal ShippingCharge {get;set;}
        public decimal Total => Subtotal + Tax + ShippingCharge;
        public decimal GrandTotal => Total - Discount;        

    }
}
