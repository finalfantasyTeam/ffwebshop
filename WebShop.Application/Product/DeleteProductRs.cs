using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class DeleteProductRs : BaseResponse<ProductDTO>
    {
        public ProductDTO Product { get; set; }
    }
}
