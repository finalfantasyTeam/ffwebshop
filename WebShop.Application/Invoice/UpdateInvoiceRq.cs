using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateInvoiceRq : BaseRequest
    {
        public InvoiceDTO Invoice { get; set; }
    }
}
