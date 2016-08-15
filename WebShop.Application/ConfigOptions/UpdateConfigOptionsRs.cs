using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateConfigOptionsRs : IOutputDto
    {
        public ConfigOptionsDTO ConfigOption { get; set; }
    }
}
