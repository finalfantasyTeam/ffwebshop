using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteCustomerGroupRq : BaseRequest
    {
        public CustomerGroupDTO Group { get; set; }
    }
}
