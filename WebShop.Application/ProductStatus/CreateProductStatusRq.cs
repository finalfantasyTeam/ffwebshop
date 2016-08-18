using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductStatusRq : BaseRequest
    {
        public ProductStatusDTO ProductStatus { get; set; }
    }
}