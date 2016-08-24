using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductMetaRq : BaseRequest
    {
        public ProductMetaDTO Meta { get; set; }
    }
}