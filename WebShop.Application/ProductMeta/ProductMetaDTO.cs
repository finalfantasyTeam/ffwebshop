using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(ProductMeta))]
    public class ProductMetaDTO : EntityDto
    {
        public ProductMetaDTO() 
        { }

        public int? ProductId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }
    }
}
