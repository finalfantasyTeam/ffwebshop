using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IOrderDetailAppService : IApplicationService
    {
        Task<ListOrderDetailRs> GetAllOrderDetails();
        Task<GetOrderDetailRs> GetOrderDetail(GetOrderDetailRq rq);
        Task<CreateOrderDetailRs> CreateOrderDetail(CreateOrderDetailRq rq);
        Task<UpdateOrderDetailRs> UpdateOrderDetail(UpdateOrderDetailRq rq);
        Task<DeleteOrderDetailRs> DeleteOrderDetail(DeleteOrderDetailRq rq);
    }
}
