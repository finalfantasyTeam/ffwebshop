using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductRq : BaseRequest
    {
        public ProductDTO Product { get; set; }
    }
}
