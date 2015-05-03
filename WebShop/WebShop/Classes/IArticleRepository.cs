using System.Collections.Generic;

namespace WebShop
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Get();

        Article Get(int id);

        Article Add(Article article);

        bool Delete(int id);

        bool Update(Article article);

        int Count();
    }
}