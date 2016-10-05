using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class ProductBranch : Entity<int>
    {
        public ProductBranch()
        {
            //Products = new HashSet<Product>();
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string BranchLogo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
