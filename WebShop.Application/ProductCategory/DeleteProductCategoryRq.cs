using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductCategoryRq : BaseRequest
    {
        public ProductCategoryDTO Category { get; set; }
    }
}
