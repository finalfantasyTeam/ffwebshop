using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateCustomerRs : BaseResponse<CustomerDTO>
    {
        public CustomerDTO Customer { get; set; }
    }
}
