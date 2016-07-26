using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductManufactoryRq : IInputDto
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
