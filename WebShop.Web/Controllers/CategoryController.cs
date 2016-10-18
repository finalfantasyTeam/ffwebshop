using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class CategoryController : WebShopControllerBase
    {
        private readonly IProductAppService _productApp;
        private readonly IProductCategoryAppService _productCatApp;
        private readonly IProductManufactoryAppService _productManuApp;
        private readonly IConfigOptionsAppService _optionApp;

        public CategoryController(IProductAppService productApp,
            IProductCategoryAppService productCatApp,
            IProductManufactoryAppService productManuApp,
            IConfigOptionsAppService optionApp)
        {
            _productApp = productApp;
            _optionApp = optionApp;
            _productCatApp = productCatApp;
            _productManuApp = productManuApp;
        }

        public async Task<ActionResult> Index(int catgoryId)
        {
            ProductPageViewModel viewModel = new ProductPageViewModel(_productApp, _productCatApp, _productManuApp, _optionApp);
            await viewModel.GetProductByCategory(catgoryId);

            ViewBag.ControllerName = ControllerName.CATEGORY;
            ViewBag.Title = "";


            return View(viewModel);
        }
    }
}