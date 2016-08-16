using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteConfigOptionsRq : IInputDto
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}
