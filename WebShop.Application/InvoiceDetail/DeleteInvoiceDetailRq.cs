using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteInvoiceDetailRq : BaseRequest
    {
        public InvoiceDetailDTO InvoiceDetail { get; set; }
    }
}
