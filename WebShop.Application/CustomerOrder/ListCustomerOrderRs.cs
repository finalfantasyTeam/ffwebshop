using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListCustomerOrderRs : BaseResponse<CustomerOrderDTO>
    {
        public List<CustomerOrderDTO> Orders { get; set; }
    }
}
