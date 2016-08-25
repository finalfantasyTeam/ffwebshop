using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductController : AdminControllerBase
    {
        private readonly IProductAppService _ProductAppService;

        public AdminProductController(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ProductViewModel viewModel = new ProductViewModel(_ProductAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ProductViewModel viewModel = new ProductViewModel(_ProductAppService);
            await viewModel.GetProduct(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductViewModel viewModel = new ProductViewModel(_ProductAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductViewModel viewModel = new ProductViewModel(_ProductAppService);
            await viewModel.GetProduct(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductViewModel viewModel)
        {
            await viewModel.CreateNewProduct();
            return RedirectToAction("Details", new { id = viewModel.Product.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductViewModel viewModel)
        {
            await viewModel.UpdateProduct();
            return RedirectToAction("Details", new { id = viewModel.Product.Id });
        }
    }
}