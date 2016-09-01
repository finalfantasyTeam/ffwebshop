using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class GetCustomerOrderRs : BaseResponse<CustomerOrderDTO>
    {
        public CustomerOrderDTO Order { get; set; }
    }
}
