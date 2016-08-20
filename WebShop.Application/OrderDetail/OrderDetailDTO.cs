using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WebShop.Core;

namespace WebShop.Application
{
    [AutoMapFrom(typeof(OrderDetail))]
    public class OrderDetailDTO : EntityDto
    {
        public OrderDetailDTO() 
        { }

        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int? OrderQuantity { get; set; }
        public decimal? OrderPrice { get; set; }
        public decimal? OrderCost { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }
    }
}
