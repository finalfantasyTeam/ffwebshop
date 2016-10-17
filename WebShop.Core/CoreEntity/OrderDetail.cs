using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace WebShop.Core
{
    public class OrderDetail : Entity<int>
    {
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int? OrderQuantity { get; set; }
        public decimal? OrderPrice { get; set; }
        public decimal? OrderCost { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product ProductOrder { get; set; }
    }
}
