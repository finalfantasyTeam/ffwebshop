﻿using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateCustomerOrderRq : BaseRequest
    {
        public CustomerOrderDTO CustomerOrder { get; set; }
    }
}