using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(ProductManufactory))]
    public class ProductManufactoryDTO : EntityDto
    {
        public ProductManufactoryDTO() 
        { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufactoryLogo { get; set; }
        public string ManufactoryCountry { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
