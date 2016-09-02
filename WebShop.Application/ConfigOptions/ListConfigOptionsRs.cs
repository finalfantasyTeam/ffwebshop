using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListConfigOptionsRs : BaseResponse<ConfigOptionsDTO>
    {
        public List<ConfigOptionsDTO> Options { get; set; }
    }
}
