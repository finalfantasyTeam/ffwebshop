using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductMetaController : AdminControllerBase
    {
        private readonly IProductMetaAppService _MetaAppService;

        public AdminProductMetaController(IProductMetaAppService MetaAppService)
        {
            _MetaAppService = MetaAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ProductMetaViewModel viewModel = new ProductMetaViewModel(_MetaAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ProductMetaViewModel viewModel = new ProductMetaViewModel(_MetaAppService);
            await viewModel.GetProductMeta(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductMetaViewModel viewModel = new ProductMetaViewModel(_MetaAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductMetaViewModel viewModel = new ProductMetaViewModel(_MetaAppService);
            await viewModel.GetProductMeta(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductMetaViewModel viewModel)
        {
            await viewModel.CreateNewProductMeta();
            return RedirectToAction("Details", new { id = viewModel.ProductMeta.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductMetaViewModel viewModel)
        {
            await viewModel.UpdateProductMeta();
            return RedirectToAction("Details", new { id = viewModel.ProductMeta.Id });
        }
    }
}