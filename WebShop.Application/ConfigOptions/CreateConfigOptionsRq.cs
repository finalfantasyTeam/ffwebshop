using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateConfigOptionsRq : IInputDto
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}