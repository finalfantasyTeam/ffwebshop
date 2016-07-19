using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class AboutController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}