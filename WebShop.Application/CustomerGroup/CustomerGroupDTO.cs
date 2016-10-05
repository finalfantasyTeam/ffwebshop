using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(CustomerGroup))]
    public class CustomerGroupDTO : EntityDto
    {
        public CustomerGroupDTO()
        { }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
