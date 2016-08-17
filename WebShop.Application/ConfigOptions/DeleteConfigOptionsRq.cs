using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteConfigOptionsRq : BaseRequest
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}
