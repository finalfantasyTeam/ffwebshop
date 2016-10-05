using System.IO;
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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            CustomerGroupViewModel viewModel = new CustomerGroupViewModel(_GroupAppService);
            await viewModel.GetCustomerGroup(id);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CustomerGroupViewModel viewModel)
        {
            CreateCustomerGroupRq rq = new CreateCustomerGroupRq()
            {
                Group = viewModel.CustomerGroup,

            };
            viewModel.CustomerGroup = (await _GroupAppService.CreateGroup(rq)).Group;
            return RedirectToAction("List", new { id = viewModel.CustomerGroup.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerGroupViewModel viewModel)
        {
            UpdateCustomerGroupRq rq = new UpdateCustomerGroupRq()
            {
                Group = viewModel.CustomerGroup
            };
            viewModel.CustomerGroup = (await _GroupAppService.UpdateGroup(rq)).Group;
            return RedirectToAction("List", new { id = viewModel.CustomerGroup.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CustomerGroupViewModel viewModel)
        {
            DeleteCustomerGroupRq rq = new DeleteCustomerGroupRq()
            { Group = viewModel.CustomerGroup };
            viewModel.CustomerGroup = (await _GroupAppService.DeleteGroup(rq)).Group;
            return RedirectToAction("List", new { id = viewModel.CustomerGroup.Id });
        }
    }
}