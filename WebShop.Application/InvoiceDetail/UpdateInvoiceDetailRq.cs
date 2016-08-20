using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateInvoiceDetailRq : BaseRequest
    {
        public InvoiceDetailDTO InvoiceDetail { get; set; }
    }
}
