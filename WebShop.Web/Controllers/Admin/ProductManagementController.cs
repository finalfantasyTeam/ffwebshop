using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class ProductManagementController : AdminControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}