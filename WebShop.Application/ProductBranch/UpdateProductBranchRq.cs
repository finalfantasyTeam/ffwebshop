using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductBranchRq : BaseRequest
    {
        public ProductBranchDTO Branch { get; set; }
    }
}
