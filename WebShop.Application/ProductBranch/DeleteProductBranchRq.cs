using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductBranchRq : BaseRequest
    {
        public ProductBranchDTO ProductBranch { get; set; }
    }
}
