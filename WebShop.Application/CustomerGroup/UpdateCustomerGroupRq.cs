﻿using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateCustomerGroupRq : BaseRequest
    {
        public CustomerGroupDTO Group { get; set; }
    }
}
