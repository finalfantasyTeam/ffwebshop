using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class AccountController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}