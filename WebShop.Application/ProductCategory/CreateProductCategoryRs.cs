using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateProductCategoryRs : BaseResponse<ProductCategoryDTO>
    {
        public ProductCategoryDTO ProductCategory { get; set; }
    }
}
