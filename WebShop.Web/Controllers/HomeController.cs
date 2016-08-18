using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class HomeController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}