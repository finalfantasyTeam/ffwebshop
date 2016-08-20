using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateCustomerRq : BaseRequest
    {
        public CustomerDTO Customer { get; set; }
    }
}