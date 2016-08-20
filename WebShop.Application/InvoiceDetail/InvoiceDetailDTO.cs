using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(InvoiceDetail))]
    public class InvoiceDetailDTO : EntityDto
    {
        public InvoiceDetailDTO() 
        { }

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
    }
}
