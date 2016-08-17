using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateConfigOptionsRq : BaseRequest
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}
