using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Controllers;

namespace WebShop.Tests.Controllers
{
    [TestClass]
    public class ArticlesControllerTest
    {
        private ArticlesController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new ArticlesController(new ArticleTestRepository());
        }

        [TestMethod]
        public void Get()
        {
            var result = _controller.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            var result = _controller.Get(5);
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            _controller.Post("value");
        }

        [TestMethod]
        public void Put()
        {
            _controller.Put(5, "value");
        }

        [TestMethod]
        public void Delete()
        {
            _controller.Delete(5);
        }
    }
}