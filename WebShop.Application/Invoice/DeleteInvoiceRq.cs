using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteInvoiceRq : BaseRequest
    {
        public InvoiceDTO Invoice { get; set; }
    }
}
