using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateCustomerRs : BaseResponse<ConfigOptionsDTO>
    {
        public CustomerDTO Customer { get; set; }
    }
}
