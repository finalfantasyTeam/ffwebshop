using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateCustomerGroupRs : BaseResponse<CustomerGroupDTO>
    {
        public CustomerGroupDTO CustomerGroup { get; set; }
    }
}
