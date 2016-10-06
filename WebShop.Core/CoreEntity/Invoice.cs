using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class Invoice : Entity<int>
    {
        public Invoice()
        {
            //Customer = new HashSet<Customer>();
        }

        public int CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public decimal? InvoiceTotal { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }

        //public virtual ICollection<Customer> Customer { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
