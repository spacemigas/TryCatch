using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}