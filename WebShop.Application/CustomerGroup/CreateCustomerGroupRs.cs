using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateCustomerGroupRs : BaseResponse<CustomerGroupDTO>
    {
        public CustomerGroupDTO Group { get; set; }
    }
}
