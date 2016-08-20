using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductRq : BaseRequest
    {
        public ProductDTO Product { get; set; }
    }
}
