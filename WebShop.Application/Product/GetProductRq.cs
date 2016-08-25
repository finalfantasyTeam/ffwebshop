using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
