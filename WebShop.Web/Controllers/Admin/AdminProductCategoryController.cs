using System.IO;
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

            var getAllCategoryRs = await _CategoryAppService.GetAllCategory();
            ViewBag.CategoryId = new SelectList(getAllCategoryRs.Categories, "Id", "Name");

            await viewModel.GetProductCategory(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);

            var getAllCategoryRs = await _CategoryAppService.GetAllCategory();
            ViewBag.CategoryId = new SelectList(getAllCategoryRs.Categories, "Id", "Name");

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            await viewModel.GetProductCategory(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            await viewModel.GetProductCategory(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> CannotDelete(int id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel(_CategoryAppService);
            await viewModel.GetProductCategory(id);
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
        public async Task<ActionResult> Create(ProductCategoryViewModel viewModel)
        {
            var uri = SaveFile();
            viewModel.ProductCategory.ImageToShow = uri;
            CreateProductCategoryRq rq = new CreateProductCategoryRq()
            {
                Category = viewModel.ProductCategory
            };
            viewModel.ProductCategory = (await _CategoryAppService.CreateCategory(rq)).Category;
            return RedirectToAction("List", new { id = viewModel.ProductCategory.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductCategoryViewModel viewModel)
        {
            var uri = SaveFile();
            if (!string.IsNullOrEmpty(uri))
            {
                viewModel.ProductCategory.ImageToShow = uri;
            }

            UpdateProductCategoryRq rq = new UpdateProductCategoryRq()
            {
                Category = viewModel.ProductCategory
            };
            viewModel.ProductCategory = (await _CategoryAppService.UpdateCategory(rq)).Category;
            return RedirectToAction("List", new { id = viewModel.ProductCategory.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductCategoryViewModel viewModel)
        {
            DeleteProductCategoryRq rq = new DeleteProductCategoryRq()
            { Category = viewModel.ProductCategory };




            viewModel.ProductCategory = (await _CategoryAppService.DeleteCategory(rq)).Category;
            if(viewModel.ProductCategory == null)
            {
                return RedirectToAction("CannotDelete", new { id = rq.Category.Id });

            }
            return RedirectToAction("List", new { id = viewModel.ProductCategory.Id });
        }
    }
}