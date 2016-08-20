using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListProductRs : BaseResponse<ProductDTO>
    {
        public List<ProductDTO> Products { get; set; }
    }
}
