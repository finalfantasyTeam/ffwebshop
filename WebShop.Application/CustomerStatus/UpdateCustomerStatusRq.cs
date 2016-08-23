using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateCustomerStatusRq : BaseRequest
    {
        public CustomerStatusDTO Status { get; set; }
    }
}
