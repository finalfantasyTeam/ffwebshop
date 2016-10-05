using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetCustomerOrderRq : BaseRequest
    {
        public int CustomerId { get; set; }
    }
}
