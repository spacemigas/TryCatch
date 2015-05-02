using System.Collections.Generic;

namespace WebShop.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Get();

        bool TryGet(int id, out Article article);

        Article Add(Article article);

        bool Delete(int id);

        bool Update(Article article);

        int Count();
    }
}