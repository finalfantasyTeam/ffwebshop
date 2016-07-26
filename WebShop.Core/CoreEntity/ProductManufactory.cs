using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace WebShop.Core
{
    public class ProductManufactory : Entity<int>
    {
        public ProductManufactory()
        { }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ManufatoryLogo { get; set; }
        public virtual string ManufactoryCountry { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual bool? IsActive { get; set; }
    }
}
