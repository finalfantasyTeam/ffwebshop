using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class AdminController : AdminControllerBase
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