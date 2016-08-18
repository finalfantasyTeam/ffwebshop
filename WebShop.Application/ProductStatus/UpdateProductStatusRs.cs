using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateProductStatusRs : BaseResponse<ProductStatusDTO>
    {
        public ProductStatusDTO ProductStatus { get; set; }
    }
}
