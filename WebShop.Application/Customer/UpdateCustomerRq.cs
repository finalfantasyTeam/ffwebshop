using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateCustomerRq : BaseRequest
    {
        public CustomerDTO Customer { get; set; }
    }
}
