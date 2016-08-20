using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class ProductCategory : Entity<int>
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
            ProductCategoryChild = new HashSet<ProductCategory>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageToShow { get; set; }
        public int ParentCat { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategoryChild { get; set; }
        public virtual ProductCategory ProductCategoryParent { get; set; }
    }
}
