using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductMetaRq : BaseRequest
    {
        public string Key { get; set; }
    }
}
