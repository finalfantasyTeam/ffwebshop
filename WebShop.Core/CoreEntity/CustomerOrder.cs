using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class CustomerOrder : Entity<int>
    {
        public CustomerOrder()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int? CustomerId { get; set; }
        public System.DateTime? CreateDate { get; set; }
        public System.DateTime? UpdateDate { get; set; }
        public System.DateTime? DeliveryDate { get; set; }
        public decimal? OrderTotal { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
