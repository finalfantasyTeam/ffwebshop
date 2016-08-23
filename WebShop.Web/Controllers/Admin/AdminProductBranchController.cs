using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductBranchController : AdminControllerBase
    {
        private readonly IProductBranchAppService _BranchAppService;

        public AdminProductBranchController(IProductBranchAppService BranchAppService)
        {
            _BranchAppService = BranchAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ProductBranchViewModel viewModel = new ProductBranchViewModel(_BranchAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ProductBranchViewModel viewModel = new ProductBranchViewModel(_BranchAppService);
            await viewModel.GetProductBranch(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductBranchViewModel viewModel = new ProductBranchViewModel(_BranchAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductBranchViewModel viewModel = new ProductBranchViewModel(_BranchAppService);
            await viewModel.GetProductBranch(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductBranchViewModel viewModel)
        {
            await viewModel.CreateNewProductBranch();
            return RedirectToAction("Details", new { id = viewModel.ProductBranch.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductBranchViewModel viewModel)
        {
            await viewModel.UpdateProductBranch();
            return RedirectToAction("Details", new { id = viewModel.ProductBranch.Id });
        }
    }
}