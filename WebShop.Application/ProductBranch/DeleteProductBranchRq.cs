using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductBranchRq : BaseRequest
    {
        public ProductBranchDTO Branch { get; set; }
    }
}
