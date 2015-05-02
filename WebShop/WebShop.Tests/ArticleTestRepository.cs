using System.Linq;
using WebShop.Models;

namespace WebShop.Tests
{
    class ArticleTestRepository : ArticleRepository
    {
        public ArticleTestRepository()
        {
            Articles = new Article[] {
                new Article { Id = 1, Category = "Test", Title = "Article1", Picture = "pic1.jpg", Price=100, Description= "Something" },
                new Article { Id = 2, Category = "Test", Title = "Article2", Picture = "pic2.jpg", Price=200, Description= "Something" },
                new Article { Id = 3, Category = "Test", Title = "Article3", Picture = "pic3.jpg", Price=300, Description= "Something" },
                new Article { Id = 4, Category = "Test", Title = "Article4", Picture = "pic4.jpg", Price=400, Description= "Something" },
            }.ToDictionary(article => article.Id);
        }
    }
}
