using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateConfigOptionsRs : BaseResponse<ConfigOptionsDTO>
    {
        public ConfigOptionsDTO Option { get; set; }
    }
}
