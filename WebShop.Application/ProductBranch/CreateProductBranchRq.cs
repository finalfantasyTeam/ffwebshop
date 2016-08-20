using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateProductBranchRq : BaseRequest
    {
        public ProductBranchDTO ProductBranch { get; set; }
    }
}