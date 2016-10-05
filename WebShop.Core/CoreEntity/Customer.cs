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
        {
            CustomerGroups = new HashSet<CustomerGroup>();
            CustomerStatus = new HashSet<CustomerStatus>();
            Users = new HashSet<Users>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Cart { get; set; }
        public string WishList { get; set; }
        public bool? Newsletter { get; set; }
        public int? CustomerGroup { get; set; }
        public string IpAddress { get; set; }
        public int? Status { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }
        public Guid? UserId { get; set; }

        //public virtual Users User { get; set; }
        //public virtual CustomerGroup CustomerGroupEntity { get; set; }
        //public virtual CustomerStatus CustomerStatus { get; set; }

        [ForeignKey("CustomerGroup")]
        public virtual CustomerGroup CustomerGroupId { get; set; }
        [ForeignKey("Status")]
        public virtual CustomerStatus CustomerStatusId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users UsersId { get; set; }
        public virtual ICollection<CustomerGroup> CustomerGroups { get; set; }
        public virtual ICollection<CustomerStatus> CustomerStatus { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
