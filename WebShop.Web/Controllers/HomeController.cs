using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class HomeController : WebShopControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IConfigOptionsAppService _configAppService;

        public HomeController(IProductAppService productApp, IConfigOptionsAppService configApp)
        {
            _productAppService = productApp;
            _configAppService = configApp;
        }

        public async Task<ActionResult> Index()
        {
            HomeViewModel viewModel = new HomeViewModel(_productAppService, _configAppService);
            ViewBag.ControllerName = ControllerName.HOME;

            await viewModel.GetDataToModel();
            return View(viewModel);
        }
    }
}