using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductStatusRq : BaseRequest
    {
        public ProductStatusDTO ProductStatus { get; set; }
    }
}
