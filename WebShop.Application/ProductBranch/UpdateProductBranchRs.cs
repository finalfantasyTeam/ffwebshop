using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateProductBranchRs : BaseResponse<ProductBranchDTO>
    {
        public ProductBranchDTO Branch { get; set; }
    }
}
