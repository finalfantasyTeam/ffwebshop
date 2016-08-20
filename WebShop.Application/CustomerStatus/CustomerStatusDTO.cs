using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(CustomerStatus))]
    public class CustomerStatusDTO : EntityDto
    {
        public CustomerStatusDTO() 
        { }

        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
