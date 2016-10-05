using System.IO;
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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ProductBranchViewModel viewModel = new ProductBranchViewModel(_BranchAppService);
            await viewModel.GetProductBranch(id);
            return View(viewModel);
        }
        private string SaveFile()
        {
            var uri = "";
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                var file = Request.Files[0];
                var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);
                var data = new byte[file.ContentLength];
                file.InputStream.Read(data, 0, file.ContentLength);
                using (var sw = new FileStream(path, FileMode.Create))
                {
                    sw.Write(data, 0, data.Length);
                }
                uri = "/Content/Files/" + file.FileName;
            }
            return uri;
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductBranchViewModel viewModel)
        {
            viewModel.ProductBranch.BranchLogo = SaveFile();
            CreateProductBranchRq rq = new CreateProductBranchRq()
            {
                Branch = viewModel.ProductBranch,

            };
            viewModel.ProductBranch = (await _BranchAppService.CreateBranch(rq)).Branch;
            return RedirectToAction("List", new { id = viewModel.ProductBranch.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductBranchViewModel viewModel)
        {
            var uri = SaveFile();
            if (!string.IsNullOrEmpty(uri))
            {
                viewModel.ProductBranch.BranchLogo = uri;
            }

            UpdateProductBranchRq rq = new UpdateProductBranchRq()
            {
                Branch = viewModel.ProductBranch
            };
            viewModel.ProductBranch = (await _BranchAppService.UpdateBranch(rq)).Branch;
            return RedirectToAction("List", new { id = viewModel.ProductBranch.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductBranchViewModel viewModel)
        {
            DeleteProductBranchRq rq = new DeleteProductBranchRq()
            { Branch = viewModel.ProductBranch };
            viewModel.ProductBranch = (await _BranchAppService.DeleteBranch(rq)).Branch;
            return RedirectToAction("List", new { id = viewModel.ProductBranch.Id });
        }
    }
}