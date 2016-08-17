using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductManufactoryRq : BaseRequest
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
