using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateCustomerOrderRq : BaseRequest
    {
        public CustomerOrderDTO CustomerOrder { get; set; }
    }
}
