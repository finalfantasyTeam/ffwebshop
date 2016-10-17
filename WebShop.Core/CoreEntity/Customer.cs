using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class Customer : Entity<int>
    {
        public Customer()
        { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Cart { get; set; }
        public string WishList { get; set; }
        public bool? Newsletter { get; set; }
        public string IpAddress { get; set; }
        public int? Status { get; set; }
        public int CustomerGroupId { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }
        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("CustomerGroupId")]
        public virtual CustomerGroup CustomerGroup { get; set; }

        [ForeignKey("Status")]
        public virtual CustomerStatus CustomerStatus { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
