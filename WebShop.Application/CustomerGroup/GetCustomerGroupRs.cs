using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class GetCustomerGroupRs : BaseResponse<CustomerGroupDTO>
    {
        public CustomerGroupDTO Group { get; set; }
    }
}
