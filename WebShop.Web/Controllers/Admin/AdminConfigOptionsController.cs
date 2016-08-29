using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminConfigOptionsController : AdminControllerBase
    {
        private readonly IConfigOptionsAppService _configOptionAppService;

        public AdminConfigOptionsController(IConfigOptionsAppService configOptionAppService)
        {
            _configOptionAppService = configOptionAppService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_configOptionAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_configOptionAppService);
            await viewModel.GetConfigOptions(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_configOptionAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_configOptionAppService);
            await viewModel.GetConfigOptions(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ConfigOptionsViewModel viewModel)
        {
            await viewModel.CreateNewConfigOptions();
            return RedirectToAction("Details", new { id = viewModel.ConfigOptions.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ConfigOptionsViewModel viewModel)
        {
            await viewModel.UpdateConfigOptions();
            return RedirectToAction("Details", new { id = viewModel.ConfigOptions.Id });
        }
    }
}