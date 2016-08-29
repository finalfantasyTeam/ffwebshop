using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateProductMetaRs : BaseResponse<ProductMetaDTO>
    {
        public ProductMetaDTO Meta { get; set; }
    }
}
