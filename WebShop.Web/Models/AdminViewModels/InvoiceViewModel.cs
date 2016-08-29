using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class InvoiceViewModel
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public InvoiceViewModel()
        {
        }

        public InvoiceViewModel(IInvoiceAppService invoiceAppService)
        {
            _invoiceAppService = invoiceAppService;
        }

        public async Task FillDataForModel()
        {
            ListInvoice = (await _invoiceAppService.GetAllInvoices()).Invoices;
        }

        public async Task GetInvoice(int id)
        {
            GetInvoiceRq rq = new GetInvoiceRq()
            { Id = id };
            Invoice = (await _invoiceAppService.GetInvoiceById(rq)).Invoice;
        }

        public async Task CreateNewInvoice()
        {
            CreateInvoiceRq rq = new CreateInvoiceRq()
            { Invoice = Invoice };
            Invoice = (await _invoiceAppService.CreateInvoice(rq)).Invoice;
        }

        public async Task UpdateInvoice()
        {
            UpdateInvoiceRq rq = new UpdateInvoiceRq()
            { Invoice = Invoice };
            Invoice = (await _invoiceAppService.UpdateInvoice(rq)).Invoice;
        }

        public async Task DeleteInvoice()
        {
            DeleteInvoiceRq rq = new DeleteInvoiceRq()
            { Invoice = Invoice };
            await _invoiceAppService.DeleteInvoice(rq);
        }

        public IList<InvoiceDTO> ListInvoice { get; set; }
        public InvoiceDTO Invoice { get; set; }
    }
}