using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListCustomerGroupRs : BaseResponse<CustomerGroupDTO>
    {
        public List<CustomerGroupDTO> Groups { get; set; }
    }
}
