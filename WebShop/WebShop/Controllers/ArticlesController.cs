using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebShop.Models;

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

        // GET api/articles
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/articles/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/articles
        public void Post([FromBody]string value)
        {
        }

        // PUT api/articles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/articles/5
        public void Delete(int id)
        {
        }
    }
}