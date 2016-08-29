using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetCustomerGroupRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
