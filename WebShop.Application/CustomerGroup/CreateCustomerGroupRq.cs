using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateCustomerGroupRq : BaseRequest
    {
        public CustomerGroupDTO CustomerGroup { get; set; }
    }
}