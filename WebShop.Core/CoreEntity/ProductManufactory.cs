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

        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufatoryLogo { get; set; }
        public string ManufactoryCountry { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
