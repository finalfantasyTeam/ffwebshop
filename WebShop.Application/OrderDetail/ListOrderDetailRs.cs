using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListOrderDetailRs : BaseResponse<OrderDetailDTO>
    {
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
