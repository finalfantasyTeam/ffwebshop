using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetConfigOptionsRq : IInputDto
    {
        public int Id { get; set; }
        public string OptionKey { get; set; }
    }
}
