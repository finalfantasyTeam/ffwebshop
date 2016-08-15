using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateConfigOptionsRs : IOutputDto
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}
