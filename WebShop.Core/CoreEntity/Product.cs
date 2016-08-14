using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class Product : Entity<int>
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductMetas = new HashSet<ProductMeta>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        public decimal? OriginPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public int? ManufactoryId { get; set; }
        public int? BranchId { get; set; }
        public System.DateTime? CreateDate { get; set; }
        public System.DateTime? UpdateDate { get; set; }
        public System.DateTime? ImportDate { get; set; }
        public string FeatureImage { get; set; }
        public string ImageList { get; set; }
        public bool? IsActive { get; set; }
        public decimal? Discount { get; set; }

        public virtual ProductBranch ProductBranch { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductMeta> ProductMetas { get; set; }
    }
}
