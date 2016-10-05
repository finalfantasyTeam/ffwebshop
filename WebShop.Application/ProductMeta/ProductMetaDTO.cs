using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public bool IsActive { get; set; } //can be null

        //[MaxLength(50)] // data annotation
        public string Notes { get; set; }
    }
}
