using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop.Controllers;

namespace WebShop.Tests
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
            var article = _controller.Get(1);
            Assert.AreEqual("Article1", article.Title);
        }
    }
}