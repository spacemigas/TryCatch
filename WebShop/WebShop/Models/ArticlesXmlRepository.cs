using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Serialization;
using System;

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
            using (var reader = new StreamReader(filename))
                _articles = ((List<Article>)deserializer.Deserialize(reader)).ToDictionary(x => x.Id);
        }

        public IEnumerable<Article> Get()
        {
            return _articles.Values.OrderBy(article => article.Id);
        }

        public bool TryGet(int id, out Article article)
        {
            return _articles.TryGetValue(id, out article);
        }

        public Article Add(Article article)
        {
            if (article == null)
                throw new ArgumentNullException("article");

            article.Id = _nextID++;
            _articles[article.Id] = article;
            return article;
        }

        public bool Delete(int id)
        {
            return _articles.Remove(id);
        }

        public bool Update(Article article)
        {
            if (article == null)
                throw new ArgumentNullException("article");

            bool update = _articles.ContainsKey(article.Id);
            _articles[article.Id] = article;
            return update;
        }
    }
}
