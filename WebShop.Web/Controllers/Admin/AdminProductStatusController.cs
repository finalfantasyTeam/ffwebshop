using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductStatusController : AdminControllerBase
    {
        private readonly IProductStatusAppService _StatusAppService;

        public AdminProductStatusController(IProductStatusAppService StatusAppService)
        {
            _StatusAppService = StatusAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ProductStatusViewModel viewModel = new ProductStatusViewModel(_StatusAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ProductStatusViewModel viewModel = new ProductStatusViewModel(_StatusAppService);
            await viewModel.GetProductStatus(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductStatusViewModel viewModel = new ProductStatusViewModel(_StatusAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductStatusViewModel viewModel = new ProductStatusViewModel(_StatusAppService);
            await viewModel.GetProductStatus(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ProductStatusViewModel viewModel = new ProductStatusViewModel(_StatusAppService);
            await viewModel.GetProductStatus(id);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductStatusViewModel viewModel)
        {
           CreateProductStatusRq rq = new CreateProductStatusRq()
            {
                Status = viewModel.ProductStatus,

            };
            viewModel.ProductStatus = (await _StatusAppService.CreateStatus(rq)).Status;
            return RedirectToAction("List", new { id = viewModel.ProductStatus.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductStatusViewModel viewModel)
        {
            UpdateProductStatusRq rq = new UpdateProductStatusRq()
            {
                Status = viewModel.ProductStatus
            };
            viewModel.ProductStatus = (await _StatusAppService.UpdateStatus(rq)).Status;
            return RedirectToAction("List", new { id = viewModel.ProductStatus.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductStatusViewModel viewModel)
        {
            DeleteProductStatusRq rq = new DeleteProductStatusRq()
            { Status = viewModel.ProductStatus };
            viewModel.ProductStatus = (await _StatusAppService.DeleteStatus(rq)).Status;
            return RedirectToAction("List", new { id = viewModel.ProductStatus.Id });
        }
    }
}