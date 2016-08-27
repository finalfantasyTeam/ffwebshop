using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class CategoryController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            ViewBag.ControllerName = "Category";
            return View();
        }
    }
}