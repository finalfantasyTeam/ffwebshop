using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductManufactoryRq : BaseRequest
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
