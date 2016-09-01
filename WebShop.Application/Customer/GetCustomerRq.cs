using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetCustomerRq : BaseRequest
    {
        public string FirstName { get; set; }
    }
}
