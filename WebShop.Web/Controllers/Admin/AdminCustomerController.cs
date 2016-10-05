using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminCustomerController : AdminControllerBase
    {
        private readonly ICustomerAppService _CustomerAppService;

        public AdminCustomerController(ICustomerAppService CustomerAppService)
        {
            _CustomerAppService = CustomerAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            CustomerViewModel viewModel = new CustomerViewModel(_CustomerAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            CustomerViewModel viewModel = new CustomerViewModel(_CustomerAppService);
            await viewModel.GetCustomer(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CustomerViewModel viewModel = new CustomerViewModel(_CustomerAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            CustomerViewModel viewModel = new CustomerViewModel(_CustomerAppService);
            await viewModel.GetCustomer(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            CustomerViewModel viewModel = new CustomerViewModel(_CustomerAppService);
            await viewModel.GetCustomer(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerViewModel viewModel)
        {
            CreateCustomerRq rq = new CreateCustomerRq()
            {
                Customer = viewModel.Customer,

            };
            viewModel.Customer = (await _CustomerAppService.CreateCustomer(rq)).Customer;
            return RedirectToAction("List", new { id = viewModel.Customer.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerViewModel viewModel)
        {
            UpdateCustomerRq rq = new UpdateCustomerRq()
            {
                Customer = viewModel.Customer
            };
            viewModel.Customer = (await _CustomerAppService.UpdateCustomer(rq)).Customer;
            return RedirectToAction("List", new { id = viewModel.Customer.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CustomerViewModel viewModel)
        {
            DeleteCustomerRq rq = new DeleteCustomerRq()
            { Customer = viewModel.Customer };
            viewModel.Customer = (await _CustomerAppService.DeleteCustomer(rq)).Customer;
            return RedirectToAction("List", new { id = viewModel.Customer.Id });
        }

    }
}