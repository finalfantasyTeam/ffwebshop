using System.IO;
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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            CustomerStatusViewModel viewModel = new CustomerStatusViewModel(_StatusAppService);
            await viewModel.GetCustomerStatus(id);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CustomerStatusViewModel viewModel)
        {
            CreateCustomerStatusRq rq = new CreateCustomerStatusRq()
            {
                Status = viewModel.CustomerStatus,

            };
            viewModel.CustomerStatus = (await _StatusAppService.CreateStatus(rq)).Status;
            return RedirectToAction("List", new { id = viewModel.CustomerStatus.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerStatusViewModel viewModel)
        {
            UpdateCustomerStatusRq rq = new UpdateCustomerStatusRq()
            {
                Status = viewModel.CustomerStatus
            };
            viewModel.CustomerStatus = (await _StatusAppService.UpdateStatus(rq)).Status;
            return RedirectToAction("List", new { id = viewModel.CustomerStatus.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CustomerStatusViewModel viewModel)
        {
            DeleteCustomerStatusRq rq = new DeleteCustomerStatusRq()
            { Status = viewModel.CustomerStatus };
            viewModel.CustomerStatus = (await _StatusAppService.DeleteStatus(rq)).Status;
            return RedirectToAction("List", new { id = viewModel.CustomerStatus.Id });
        }
    }
}