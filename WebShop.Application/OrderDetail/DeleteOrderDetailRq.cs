using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteOrderDetailRq : BaseRequest
    {
        public OrderDetailDTO OrderDetail { get; set; }
    }
}
