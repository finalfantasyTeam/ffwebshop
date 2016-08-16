using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateConfigOptionsRq : IInputDto
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}
