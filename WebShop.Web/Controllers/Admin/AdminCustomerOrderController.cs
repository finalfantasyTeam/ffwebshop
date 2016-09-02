using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminCustomerOrderController : AdminControllerBase
    {
        private readonly ICustomerOrderAppService _OrderAppService;
        //private readonly ICustomerAppService _CustomerAppService;

        //public AdminCustomerOrderController(ICustomerOrderAppService OrderAppService, ICustomerAppService CustomerAppService)
        //{
        //    _OrderAppService = OrderAppService;
        //    _CustomerAppService = CustomerAppService;
        //}

        public AdminCustomerOrderController(ICustomerOrderAppService OrderAppService)
        {
            _OrderAppService = OrderAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            CustomerOrderViewModel viewModel = new CustomerOrderViewModel(_OrderAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            CustomerOrderViewModel viewModel = new CustomerOrderViewModel(_OrderAppService);
            //var getAllCustomerRs = await _CustomerAppService.GetAllCustomer();
            //ViewBag.CustomerId = new SelectList(getAllCustomerRs.Customers, "Id", "FirstName");
            await viewModel.GetCustomerOrder(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            CustomerOrderViewModel viewModel = new CustomerOrderViewModel(_OrderAppService);
            //var getAllCustomerRs = await _CustomerAppService.GetAllCustomer();
            //ViewBag.CustomerId = new SelectList(getAllCustomerRs.Customers, "Id", "FirstName");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            CustomerOrderViewModel viewModel = new CustomerOrderViewModel(_OrderAppService);
            await viewModel.GetCustomerOrder(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            CustomerOrderViewModel viewModel = new CustomerOrderViewModel(_OrderAppService);
            await viewModel.GetCustomerOrder(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerOrderViewModel viewModel)
        {
            CreateCustomerOrderRq rq = new CreateCustomerOrderRq()
            {
                Order = viewModel.CustomerOrder,

            };
            viewModel.CustomerOrder = (await _OrderAppService.CreateOrder(rq)).Order;
            return RedirectToAction("List", new { id = viewModel.CustomerOrder.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(CustomerOrderViewModel viewModel)
        {
            UpdateCustomerOrderRq rq = new UpdateCustomerOrderRq()
            {
                Order = viewModel.CustomerOrder
            };
            viewModel.CustomerOrder = (await _OrderAppService.UpdateOrder(rq)).Order;
            return RedirectToAction("List", new { id = viewModel.CustomerOrder.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CustomerOrderViewModel viewModel)
        {
            DeleteCustomerOrderRq rq = new DeleteCustomerOrderRq()
            { Order = viewModel.CustomerOrder };
            viewModel.CustomerOrder = (await _OrderAppService.DeleteOrder(rq)).Order;
            return RedirectToAction("List", new { id = viewModel.CustomerOrder.Id });
        }

    }
}