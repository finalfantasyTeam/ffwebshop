using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class ProductMeta : Entity<int>
    {
        public ProductMeta()
        {
            Products = new HashSet<Product>();
        }

        public int? ProductId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product ProductParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
