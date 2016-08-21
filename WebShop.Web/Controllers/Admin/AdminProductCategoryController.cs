using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductCategoryController : AdminControllerBase
    {
        private readonly IProductCategoryAppService _CategoryAppService;

        public AdminProductCategoryController(IProductCategoryAppService CategoryAppService)
        {
            _CategoryAppService = CategoryAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            await viewModel.GetProductCategory(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            await viewModel.GetProductCategory(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryViewModel viewModel)
        {
            await viewModel.CreateNewProductCategory();
            return RedirectToAction("Details", new { id = viewModel.ProductCategory.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductCategoryViewModel viewModel)
        {
            await viewModel.UpdateProductCategory();
            return RedirectToAction("Details", new { id = viewModel.ProductCategory.Id });
        }
    }
}