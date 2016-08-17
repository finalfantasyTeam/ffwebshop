using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateConfigOptionsRq : BaseRequest
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}