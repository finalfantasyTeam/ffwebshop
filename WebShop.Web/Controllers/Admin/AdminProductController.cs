using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;
using System.Linq;
namespace WebShop.Web.Controllers
{
    public class AdminProductController : AdminControllerBase
    {
        private readonly IProductAppService _ProductAppService;
        private readonly IProductCategoryAppService productCategoryAppService;
        private readonly IProductStatusAppService productStatusAppService;
        private readonly IProductManufactoryAppService productManufactoryAppService;
        private readonly IProductBranchAppService productBranchAppService;

        public AdminProductController(IProductAppService ProductAppService, IProductCategoryAppService productCategoryAppService,
            IProductStatusAppService productStatusAppService, IProductManufactoryAppService productManufactoryAppService,
            IProductBranchAppService productBranchAppService)
        {
            _ProductAppService = ProductAppService;
            this.productCategoryAppService = productCategoryAppService;
            this.productStatusAppService = productStatusAppService;
            this.productManufactoryAppService = productManufactoryAppService;
            this.productBranchAppService = productBranchAppService;
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
            ViewBag.Categories = (await productCategoryAppService.GetAllCategory()).Categories.Select(x =>  new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            ViewBag.Status = (await productStatusAppService.GetAllStatus()).Statuses.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(); ;
            ViewBag.Manufactories = (await productManufactoryAppService.GetAllManufactory()).Manufactories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(); ;
            ViewBag.Branchs = (await productBranchAppService.GetAllBranch()).Branches.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList(); ;
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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ProductViewModel viewModel = new ProductViewModel(_ProductAppService);
            await viewModel.GetProduct(id);
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
        public async Task<ActionResult> Create(ProductViewModel viewModel)
        {
            viewModel.Product.FeatureImage = SaveFile();
            CreateProductRq rq = new CreateProductRq()
            {
                Product = viewModel.Product,

            };
            viewModel.Product = (await _ProductAppService.CreateProduct(rq)).Product;
            return RedirectToAction("List", new { id = viewModel.Product.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductViewModel viewModel)
        {
            var uri = SaveFile();
            if (!string.IsNullOrEmpty(uri))
            {
                viewModel.Product.FeatureImage = uri;
            }

            UpdateProductRq rq = new UpdateProductRq()
            {
                Product = viewModel.Product
            };
            viewModel.Product = (await _ProductAppService.UpdateProduct(rq)).Product;
            return RedirectToAction("List", new { id = viewModel.Product.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductViewModel viewModel)
        {
            DeleteProductRq rq = new DeleteProductRq()
            { Product = viewModel.Product };
            viewModel.Product = (await _ProductAppService.DeleteProduct(rq)).Product;
            return RedirectToAction("List", new { id = viewModel.Product.Id });
        }
    }
}