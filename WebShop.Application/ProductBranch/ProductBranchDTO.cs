using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(ProductBranch))]
    public class ProductBranchDTO : EntityDto
    {
        public ProductBranchDTO() 
        { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string BranchLogo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
