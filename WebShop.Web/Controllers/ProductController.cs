using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ProductController : WebShopControllerBase
    {
        private readonly IProductAppService _productApp;
        private readonly IProductCategoryAppService _productCatApp;
        private readonly IProductManufactoryAppService _productManuApp;
        private readonly IConfigOptionsAppService _optionApp;

        public ProductController(IProductAppService productApp, 
            IProductCategoryAppService productCatApp, 
            IProductManufactoryAppService productManuApp, 
            IConfigOptionsAppService optionApp)
        {
            _productApp = productApp;
            _optionApp = optionApp;
            _productCatApp = productCatApp;
            _productManuApp = productManuApp;
        }

        public async Task<ActionResult> Index(int productId)
        {
            ProductPageViewModel viewModel = new ProductPageViewModel(_productApp, _productCatApp, _productManuApp, _optionApp);

            await viewModel.GetProduct(productId);
            await viewModel.GetDataToModel();

            ViewBag.Title = viewModel.Product.Name;
            ViewBag.ControllerName = ControllerName.PRODUCT;

            return View(viewModel);
        }
    }
}