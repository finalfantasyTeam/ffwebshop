using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Application;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AdminInvoiceController : AdminControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public AdminInvoiceController(IInvoiceAppService InvoiceAppService)
        {
            _invoiceAppService = InvoiceAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel(_invoiceAppService);
            await viewModel.FillDataForModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            InvoiceViewModel viewModel = new InvoiceViewModel(_invoiceAppService);
            await viewModel.GetInvoice(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel(_invoiceAppService);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            InvoiceViewModel viewModel = new InvoiceViewModel(_invoiceAppService);
            await viewModel.GetInvoice(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(InvoiceViewModel viewModel)
        {
            CreateInvoiceRq rq = new CreateInvoiceRq()
            { Invoice = viewModel.Invoice };
            viewModel.Invoice = (await _invoiceAppService.CreateInvoice(rq)).Invoice;

            return RedirectToAction("Details", new { id = viewModel.Invoice.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(InvoiceViewModel viewModel)
        {
            await viewModel.UpdateInvoice();
            return RedirectToAction("Details", new { id = viewModel.Invoice.Id });
        }
    }
}