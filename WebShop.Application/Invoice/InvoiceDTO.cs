using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(Invoice))]
    public class InvoiceDTO : EntityDto
    {
        public InvoiceDTO() 
        { }

        public int? CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public decimal? InvoiceTotal { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}
