using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminConfigOptionsController : AdminControllerBase
    {
        private readonly IConfigOptionsAppService _OptionAppService;

        public AdminConfigOptionsController(IConfigOptionsAppService OptionAppService)
        {
            _OptionAppService = OptionAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_OptionAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_OptionAppService);
            await viewModel.GetConfigOptions(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_OptionAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_OptionAppService);
            await viewModel.GetConfigOptions(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ConfigOptionsViewModel viewModel = new ConfigOptionsViewModel(_OptionAppService);
            await viewModel.GetConfigOptions(id);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ConfigOptionsViewModel viewModel)
        {
            CreateConfigOptionsRq rq = new CreateConfigOptionsRq()
            {
                Option = viewModel.ConfigOptions,

            };
            viewModel.ConfigOptions = (await _OptionAppService.CreateOption(rq)).Option;
            return RedirectToAction("List", new { id = viewModel.ConfigOptions.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ConfigOptionsViewModel viewModel)
        {
            UpdateConfigOptionsRq rq = new UpdateConfigOptionsRq()
            {
                Option = viewModel.ConfigOptions
            };
            viewModel.ConfigOptions = (await _OptionAppService.UpdateOption(rq)).Option;
            return RedirectToAction("List", new { id = viewModel.ConfigOptions.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ConfigOptionsViewModel viewModel)
        {
            DeleteConfigOptionsRq rq = new DeleteConfigOptionsRq()
            { Option = viewModel.ConfigOptions };
            viewModel.ConfigOptions = (await _OptionAppService.DeleteOption(rq)).Option;
            return RedirectToAction("List", new { id = viewModel.ConfigOptions.Id });
        }
    }
}