using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebShop.Controllers
{
    public class ArticlesController : ApiController
    {
        private const int _pageSize = 10;
        private IArticleRepository _repository;

        public ArticlesController(IArticleRepository repository)
        {
            _repository = repository;
        }

        public int GetArticles(string pages)
        {
            return (int)Math.Ceiling((double)_repository.Count() / _pageSize);
        }

        public IEnumerable<Article> GetArticles(int page)
        {
            return _repository.Get().Skip((page > 0 ? page - 1 : 0) * _pageSize).Take(_pageSize);
        }

        public Article Get(int id)
        {
            Article article;
            _repository.TryGet(id, out article);
            return article;
        }

        public void Post([FromBody]Article article)
        {
            _repository.Add(article);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}