using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductCategoryRq : BaseRequest
    {
        public string Name { get; set; }
    }
}
