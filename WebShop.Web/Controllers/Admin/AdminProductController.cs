using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class AdminProductController : AdminControllerBase
    {
        //private readonly IProductAppService _manufactoryAppService;

        public ActionResult Index()
        {
            return View();
        }
    }
}