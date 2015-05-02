using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ArticlesController : ApiController
    {
        private IArticleRepository _repository;

        public ArticlesController(IArticleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Article> GetArticles(int page)
        {
            var size = 10;
            return _repository.Get().Skip((page > 0 ? page - 1 : 0) * size).Take(size);
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