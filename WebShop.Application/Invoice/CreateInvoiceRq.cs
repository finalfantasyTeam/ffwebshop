using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateInvoiceRq : BaseRequest
    {
        public InvoiceDTO Invoice { get; set; }
    }
}