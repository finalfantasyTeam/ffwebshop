using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class SalesController : WebShopControllerBase
    {

        private readonly IProductAppService _productApp;
        private readonly IProductCategoryAppService _productCatApp;
        private readonly IConfigOptionsAppService _optionApp;

        public SalesController(IProductAppService productApp,
            IProductCategoryAppService productCatApp,
            IConfigOptionsAppService optionApp)
        {
            _productApp = productApp;
            _optionApp = optionApp;
            _productCatApp = productCatApp;
        }

        public async Task<ActionResult> Index()
        {
            SalesViewModel viewModel = new SalesViewModel(_productApp, _productCatApp, _optionApp);

            await viewModel.GetDataToModel();

            ViewBag.Title = ControllerName.SALES;
            ViewBag.ControllerName = ControllerName.SALES;

            return View(viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult OrdersList()
        {
            return PartialView("_OrdersList", null);
        }

        [HttpPost]
        public async Task<ActionResult> ReceiveCartBox(string shoppingCart)
        {
            SalesViewModel viewModel = new SalesViewModel(_productApp, _productCatApp, _optionApp);
            await viewModel.GetProductInCarts(shoppingCart);

            return PartialView("_OrdersList", viewModel);
        }

        public ActionResult SendOrder()
        {
            return View();
        }
    }
}