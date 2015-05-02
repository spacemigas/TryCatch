using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Models
{
    public class ArticleRepository : IArticleRepository
    {
        private int _nextID = 0;

        protected Dictionary<int, Article> Articles { get; set; }

        public IEnumerable<Article> Get()
        {
            return Articles.Values.OrderBy(article => article.Id);
        }

        public bool TryGet(int id, out Article article)
        {
            return Articles.TryGetValue(id, out article);
        }

        public Article Add(Article article)
        {
            if (article == null)
                throw new ArgumentNullException("article");

            article.Id = _nextID++;
            Articles[article.Id] = article;
            return article;
        }

        public bool Delete(int id)
        {
            return Articles.Remove(id);
        }

        public bool Update(Article article)
        {
            if (article == null)
                throw new ArgumentNullException("article");

            bool update = Articles.ContainsKey(article.Id);
            Articles[article.Id] = article;
            return update;
        }
    }
}