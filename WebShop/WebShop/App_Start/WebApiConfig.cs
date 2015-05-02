using System.Web.Http;
using Ninject;
using WebApiContrib.IoC.Ninject;
using WebShop.Models;

namespace WebShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IArticleRepository>().ToConstant(new ArticlesXmlRepository());
                config.DependencyResolver = new NinjectResolver(kernel);
            }
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
