using System.Diagnostics;
using System.Web.Http;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class OrderController : ApiController
    {
        public void PostOrder([FromBody]Order order)
        {
            Debugger.Break();
        }
    }
}