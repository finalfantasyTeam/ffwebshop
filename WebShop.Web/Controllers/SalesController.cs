using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class SalesController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            ViewBag.ControllerName = "Sales";
            return View();
        }

        public ActionResult SendOrder()
        {
            return View();
        }
    }
}