using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductStatusRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
