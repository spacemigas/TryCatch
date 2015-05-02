using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace WebShop.Models
{
    public class ArticleXmlRepository : ArticleRepository
    {
        public ArticleXmlRepository()
        {
            var deserializer = new XmlSerializer(typeof(List<Article>));
            var filename = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data\Articles.xml");
            using (var reader = new StreamReader(filename))
                Articles = ((List<Article>)deserializer.Deserialize(reader)).ToDictionary(article => article.Id);
        }
    }
}
