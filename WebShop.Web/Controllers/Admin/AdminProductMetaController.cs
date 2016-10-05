using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminProductMetaController : AdminControllerBase
    {
        private readonly IProductMetaAppService _MetaAppService;
        private readonly IProductAppService _ProductAppService;

        public AdminProductMetaController(IProductMetaAppService MetaAppService, IProductAppService ProductAppService)
        {
            _MetaAppService = MetaAppService;
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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ProductMetaViewModel viewModel = new ProductMetaViewModel(_MetaAppService);
            await viewModel.GetProductMeta(id);
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(ProductMetaViewModel viewModel)
        {
            CreateProductMetaRq rq = new CreateProductMetaRq()
            {
                Meta = viewModel.ProductMeta,

            };
            viewModel.ProductMeta = (await _MetaAppService.CreateMeta(rq)).Meta;
            return RedirectToAction("List", new { id = viewModel.ProductMeta.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductMetaViewModel viewModel)
        {
            UpdateProductMetaRq rq = new UpdateProductMetaRq()
            {
                Meta = viewModel.ProductMeta
            };
            viewModel.ProductMeta = (await _MetaAppService.UpdateMeta(rq)).Meta;
            return RedirectToAction("List", new { id = viewModel.ProductMeta.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductMetaViewModel viewModel)
        {
            DeleteProductMetaRq rq = new DeleteProductMetaRq()
            { Meta = viewModel.ProductMeta };
            viewModel.ProductMeta = (await _MetaAppService.DeleteMeta(rq)).Meta;
            return RedirectToAction("List", new { id = viewModel.ProductMeta.Id });
        }
        
    }
}