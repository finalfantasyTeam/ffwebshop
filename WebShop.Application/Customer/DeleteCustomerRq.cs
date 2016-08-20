using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteCustomerRq : BaseRequest
    {
        public CustomerDTO Customer { get; set; }
    }
}
