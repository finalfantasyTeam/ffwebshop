using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminCustomerStatusController : AdminControllerBase
    {
        private readonly ICustomerStatusAppService _StatusAppService;

        public AdminCustomerStatusController(ICustomerStatusAppService StatusAppService)
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
            CustomerStatusViewModel viewModel = new CustomerStatusViewModel(_StatusAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            CustomerStatusViewModel viewModel = new CustomerStatusViewModel(_StatusAppService);
            await viewModel.GetCustomerStatus(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CustomerStatusViewModel viewModel = new CustomerStatusViewModel(_StatusAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            CustomerStatusViewModel viewModel = new CustomerStatusViewModel(_StatusAppService);
            await viewModel.GetCustomerStatus(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerStatusViewModel viewModel)
        {
            await viewModel.CreateNewCustomerStatus();
            return RedirectToAction("Details", new { id = viewModel.CustomerStatus.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerStatusViewModel viewModel)
        {
            await viewModel.UpdateCustomerStatus();
            return RedirectToAction("Details", new { id = viewModel.CustomerStatus.Id });
        }
    }
}