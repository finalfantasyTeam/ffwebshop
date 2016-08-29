using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteCustomerStatusRq : BaseRequest
    {
        public CustomerStatusDTO Status { get; set; }
    }
}
