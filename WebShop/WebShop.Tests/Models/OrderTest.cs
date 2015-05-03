using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebShop.Tests
{
    [TestClass()]
    public class OrderTest
    {
        [TestMethod()]
        public void UpdateTest()
        {
            var order = new Order();
            order.Details.Add(new OrderDetail { ArticleID = 1, Price = 10m, Quantity = 2 });
            order.Details.Add(new OrderDetail { ArticleID = 2, Price = 20.2m, Quantity = 1 });
            order.Update();
            Assert.AreEqual(40.2m, order.Subtotal);
            Assert.AreEqual(9.25m, order.Vat);
            Assert.AreEqual(49.45m, order.Total);
        }
    }
}