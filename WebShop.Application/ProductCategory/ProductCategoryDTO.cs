using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(ProductCategory))]
    public class ProductCategoryDTO : EntityDto
    {
        public ProductCategoryDTO() 
        { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageToShow { get; set; }
        public int ParentCat { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }

        public List<ProductCategoryDTO> ProductCategoryChild { get; set; }
    }
}
