using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductManufactoryRq : IInputDto
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
