using System;
using System.Web.Http;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class OrdersController : ApiController
    {
        private OrdersContext _db = new OrdersContext();

        public void PostOrders([FromBody]Order order)
        {
            order.DateTime = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}