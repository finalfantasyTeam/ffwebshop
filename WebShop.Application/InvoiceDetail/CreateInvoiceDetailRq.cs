using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateInvoiceDetailRq : BaseRequest
    {
        public InvoiceDetailDTO InvoiceDetail { get; set; }
    }
}