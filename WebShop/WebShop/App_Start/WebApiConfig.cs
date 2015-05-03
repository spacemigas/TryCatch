using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Ninject;
using WebApiContrib.IoC.Ninject;

namespace WebShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IArticleRepository>().ToConstant(new ArticleXmlRepository());
            config.DependencyResolver = new NinjectResolver(kernel);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}