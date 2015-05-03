using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace WebShop
{
    public class ArticleXmlRepository : ArticleRepository
    {
        private string _filename;

        public ArticleXmlRepository()
        {
            _filename = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data\Articles.xml");
            var deserializer = new XmlSerializer(typeof(List<Article>));
            using (var reader = new StreamReader(_filename))
                Articles = ((List<Article>)deserializer.Deserialize(reader)).ToDictionary(article => article.ArticleID);
        }

        private void Save()
        {
            var serializer = new XmlSerializer(typeof(List<Article>));
            using (var writer = new StreamWriter(_filename))
                serializer.Serialize(writer, Articles.Values.ToList());
        }

        public override Article Add(Article article)
        {
            var result = base.Add(article);
            Save();
            return result;
        }

        public override bool Update(Article article)
        {
            var result = base.Update(article);
            Save();
            return result;
        }

        public override bool Delete(int id)
        {
            var result = base.Delete(id);
            Save();
            return result;
        }
    }
}