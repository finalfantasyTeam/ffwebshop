using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateOrderDetailRq : BaseRequest
    {
        public OrderDetailDTO OrderDetail { get; set; }
    }
}