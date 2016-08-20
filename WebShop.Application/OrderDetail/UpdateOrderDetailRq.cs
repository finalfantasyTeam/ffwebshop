using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateOrderDetailRq : BaseRequest
    {
        public OrderDetailDTO OrderDetail { get; set; }
    }
}
