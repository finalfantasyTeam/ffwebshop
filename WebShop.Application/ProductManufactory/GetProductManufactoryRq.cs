using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductManufactoryRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
