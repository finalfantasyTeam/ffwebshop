using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDTO : EntityDto
    {
        public ProductDTO() 
        { }

        public string Name { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        public decimal? OriginPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public int? ManufactoryId { get; set; }
        public int? BranchId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? ImportDate { get; set; }
        public string FeatureImage { get; set; }
        public string ImageList { get; set; }
        public bool? IsActive { get; set; }
        public decimal? Discount { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductBranch ProductBranch { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
