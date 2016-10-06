using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(CustomerOrder))]
    public class CustomerOrderDTO : EntityDto
    {
        public CustomerOrderDTO() 
        { }

        public int? CustomerId { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeliveryDate { get; set; }        
        public decimal? OrderTotal { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}
