using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductBranchRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
