using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetInvoiceRq : BaseRequest
    {
        public int Id { get; set; }
    }
}
