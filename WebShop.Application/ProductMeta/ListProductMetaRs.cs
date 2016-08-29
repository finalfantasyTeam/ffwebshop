using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListProductMetaRs : BaseResponse<ProductMetaDTO>
    {
        public List<ProductMetaDTO> Metas { get; set; }
    }
}
