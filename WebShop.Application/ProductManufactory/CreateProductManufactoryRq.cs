using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductManufactoryRq : IInputDto
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
