using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListCustomerRs : BaseResponse<CustomerDTO>
    {
        public List<CustomerDTO> Customers { get; set; }
    }
}
