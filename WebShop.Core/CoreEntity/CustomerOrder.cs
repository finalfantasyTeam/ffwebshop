using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Core
{
    public class CustomerOrder : Entity<int>
    {
        public CustomerOrder()
        {
            //Customers = new HashSet<Customer>();
        }

        public int? CustomerId { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? OrderTotal { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }

        //public virtual ICollection<Customer> Customers { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customers { get; set; }
    }
}
