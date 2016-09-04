using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Helpers;
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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ProductManufactoryViewModel viewModel = new ProductManufactoryViewModel(_manufactoryAppService);
            await viewModel.GetProductManufactory(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductManufactoryViewModel viewModel)
        {
            viewModel.ProductManufactory.ManufactoryLogo = string.Empty;

            if (Request.Files.Count > 0)
            {
                string fileName = FileUploadHelpers.FileNameBuilder(viewModel.ProductManufactory.Name, Request.Files[0].FileName);
                string folderName = Server.MapPath(ConfigurationManager.AppSettings.Get("LogoUploadFilePath"));
                string filePath = Path.Combine(folderName, fileName);
                await FileUploadHelpers.SaveImagesFile(Request.Files[0].InputStream, filePath);
                viewModel.ProductManufactory.ManufactoryLogo = Path.Combine(ConfigurationManager.AppSettings.Get("LogoUploadFilePath"), fileName);
            }

            CreateProductManufactoryRq rq = new CreateProductManufactoryRq()
            { Manufactory = viewModel.ProductManufactory };

            viewModel.ProductManufactory = (await _manufactoryAppService.CreateManufactory(rq)).Manufactory;

            return RedirectToAction("List", new { id = viewModel.ProductManufactory.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductManufactoryViewModel viewModel)
        {
            UpdateProductManufactoryRq rq = new UpdateProductManufactoryRq()
            { Manufactory = viewModel.ProductManufactory };
            viewModel.ProductManufactory = (await _manufactoryAppService.UpdateManufactory(rq)).Manufactory;

            return RedirectToAction("List", new { id = viewModel.ProductManufactory.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductManufactoryViewModel viewModel)
        {
            DeleteProductManufactoryRq rq = new DeleteProductManufactoryRq()
            { Manufactory = viewModel.ProductManufactory };
            viewModel.ProductManufactory = (await _manufactoryAppService.DeleteManufactory(rq)).Manufactory;

            return RedirectToAction("List", new { id = viewModel.ProductManufactory.Id });
        }
    }
}