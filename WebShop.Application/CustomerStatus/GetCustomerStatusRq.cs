using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetCustomerStatusRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
