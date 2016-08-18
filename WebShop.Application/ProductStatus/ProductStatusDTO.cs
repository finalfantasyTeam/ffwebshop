using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(ProductStatus))]
    public class ProductStatusDTO : EntityDto
    {
        public ProductStatusDTO() 
        { }

        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
