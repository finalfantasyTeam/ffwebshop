using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductStatusRq : BaseRequest
    {
        public ProductStatusDTO ProductStatus { get; set; }
    }
}
