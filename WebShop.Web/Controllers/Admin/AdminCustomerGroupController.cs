using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminCustomerGroupController : AdminControllerBase
    {
        private readonly ICustomerGroupAppService _GroupAppService;

        public AdminCustomerGroupController(ICustomerGroupAppService GroupAppService)
        {
            _GroupAppService = GroupAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            CustomerGroupViewModel viewModel = new CustomerGroupViewModel(_GroupAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            CustomerGroupViewModel viewModel = new CustomerGroupViewModel(_GroupAppService);
            await viewModel.GetCustomerGroup(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CustomerGroupViewModel viewModel = new CustomerGroupViewModel(_GroupAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            CustomerGroupViewModel viewModel = new CustomerGroupViewModel(_GroupAppService);
            await viewModel.GetCustomerGroup(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerGroupViewModel viewModel)
        {
            await viewModel.CreateNewCustomerGroup();
            return RedirectToAction("Details", new { id = viewModel.CustomerGroup.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerGroupViewModel viewModel)
        {
            await viewModel.UpdateCustomerGroup();
            return RedirectToAction("Details", new { id = viewModel.CustomerGroup.Id });
        }
    }
}