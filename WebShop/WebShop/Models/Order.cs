using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop
{
    public class Order
    {
        public const decimal VatRate = 0.23m;

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

        public void Update()
        {
            DateTime = DateTime.UtcNow;
            Subtotal = Details.Sum(item => item.Price * item.Quantity);
            Vat = Math.Round(Subtotal * VatRate, 2);
            Total = Subtotal + Vat;
        }
    }
}