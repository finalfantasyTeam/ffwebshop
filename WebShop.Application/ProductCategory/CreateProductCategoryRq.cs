using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductCategoryRq : BaseRequest
    {
        public ProductCategoryDTO Category { get; set; }
    }
}