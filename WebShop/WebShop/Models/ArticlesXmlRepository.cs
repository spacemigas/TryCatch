using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace WebShop.Models
{
    public class ArticlesXmlRepository : IArticleRepository
    {
        int _nextID = 0;
        Dictionary<int, Article> _articles;

        public ArticlesXmlRepository()
        {
            var deserializer = new XmlSerializer(typeof(List<Article>));
            var filename = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data\Articles.xml");
            _articles = ((List<Article>)deserializer.Deserialize(new StreamReader(filename))).ToDictionary(x => x.ID);
        }

        public IEnumerable<Article> Get()
        {
            return _articles.Values.OrderBy(article => article.ID);
        }

        public bool TryGet(int id, out Article article)
        {
            return _articles.TryGetValue(id, out article);
        }

        public Article Add(Article article)
        {
            article.ID = _nextID++;
            _articles[article.ID] = article;
            return article;
        }

        public bool Delete(int id)
        {
            return _articles.Remove(id);
        }

        public bool Update(Article article)
        {
            bool update = _articles.ContainsKey(article.ID);
            _articles[article.ID] = article;
            return update;
        }
    }
}
