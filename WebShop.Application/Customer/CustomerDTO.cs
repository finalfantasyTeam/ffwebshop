using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(Customer))]
    public class CustomerDTO : EntityDto
    {
        public CustomerDTO() 
        { }

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
    }
}
