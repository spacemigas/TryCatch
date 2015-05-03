using System;
using System.Collections.Generic;

namespace WebShop
{
    public class Order
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Vat { get; set; }

        public decimal Total { get; set; }

        public ICollection<OrderDetail> Details { get; private set; }

        public Customer Customer { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }
    }
}