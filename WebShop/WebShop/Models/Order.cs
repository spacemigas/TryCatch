using System;
using System.Collections.Generic;

namespace WebShop.Models
{
    public class Order
    {
        public Customer Customer { get; set; }
        public DateTime DateTime { get; set; }
        public decimal SubTotal { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetail> Details { get; private set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }
    }
}