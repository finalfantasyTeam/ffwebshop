using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class GetProductMetaRs : BaseResponse<ProductMetaDTO>
    {
        public ProductMetaDTO ProductMeta { get; set; }
    }
}
