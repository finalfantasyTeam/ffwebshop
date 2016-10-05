using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class ProductController : WebShopControllerBase
    {
        public ActionResult Index(int productId)
        {
            ViewBag.ControllerName = "Product";
            return View();
        }
    }
}