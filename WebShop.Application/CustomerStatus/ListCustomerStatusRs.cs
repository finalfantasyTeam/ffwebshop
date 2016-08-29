using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListCustomerStatusRs : BaseResponse<CustomerStatusDTO>
    {
        public List<CustomerStatusDTO> Statuses { get; set; }
    }
}
