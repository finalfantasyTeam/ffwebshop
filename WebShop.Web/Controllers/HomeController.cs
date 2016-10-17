using System.Linq;
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
            await viewModel.GetDataToModel();

            ViewBag.ControllerName = ControllerName.HOME;
            ViewBag.Title = viewModel.ConfigOptions.Where(o => o.OptionKey == "SiteName")
                                                    .Select(o => o.OptionValue)
                                                    .SingleOrDefault();

            return View(viewModel);
        }
    }
}