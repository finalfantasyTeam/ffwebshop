using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetConfigOptionsRq : BaseRequest
    {
        public string OptionKey { get; set; }
    }
}
