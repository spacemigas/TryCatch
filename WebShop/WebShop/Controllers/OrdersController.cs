using System;
using System.Web.Http;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class OrdersController : ApiController
    {
        private OrdersContext _db = new OrdersContext();

        public Order PostOrders([FromBody]Order order)
        {
            order.Update();
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            return order;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}