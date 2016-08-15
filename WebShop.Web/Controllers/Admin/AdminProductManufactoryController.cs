using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
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
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductManufactoryViewModel viewModel)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductManufactoryViewModel viewModel)
        {
            return View();
        }
    }
}