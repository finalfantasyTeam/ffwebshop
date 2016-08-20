using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductRq : BaseRequest
    {
        public ProductDTO Product { get; set; }
    }
}