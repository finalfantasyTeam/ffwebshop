using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class DashboardController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            return View("Index", "_AdminLayout", null);
        }
    }
}