using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace WebShop.Core
{
    public class InvoiceDetail : Entity<int>
    {
        public int? ProductId { get; set; }
        public int? InvoiceId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product ProductPurchase { get; set; }
    }
}
