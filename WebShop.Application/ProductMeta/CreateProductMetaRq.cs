using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductMetaRq : BaseRequest
    {
        public ProductMetaDTO ProductMeta { get; set; }
    }
}