using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListProductCategoryRs : BaseResponse<ProductCategoryDTO>
    {
        public List<ProductCategoryDTO> ProductCategories { get; set; }
    }
}
