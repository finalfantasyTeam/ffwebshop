using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class AdminController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}