using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateProductBranchRs : BaseResponse<ProductBranchDTO>
    {
        public ProductBranchDTO ProductBranch { get; set; }
    }
}
