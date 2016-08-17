using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductManufactoryController : AdminControllerBase
    {
        private readonly IProductManufactoryAppService _manufactoryAppService;

        public AdminProductManufactoryController(IProductManufactoryAppService manufactoryAppService)
        {
            _manufactoryAppService = manufactoryAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ProductManufactoryViewModel viewModel = new ProductManufactoryViewModel(_manufactoryAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ProductManufactoryViewModel viewModel = new ProductManufactoryViewModel(_manufactoryAppService);
            await viewModel.GetProductManufactory(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductManufactoryViewModel viewModel = new ProductManufactoryViewModel(_manufactoryAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductManufactoryViewModel viewModel = new ProductManufactoryViewModel(_manufactoryAppService);
            await viewModel.GetProductManufactory(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductManufactoryViewModel viewModel)
        {
            await viewModel.CreateNewProductManufactory();
            return RedirectToAction("Details", new { id = viewModel.ProductManufactory.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductManufactoryViewModel viewModel)
        {
            await viewModel.UpdateProductManufactory();
            return RedirectToAction("Details", new { id = viewModel.ProductManufactory.Id });
        }
    }
}