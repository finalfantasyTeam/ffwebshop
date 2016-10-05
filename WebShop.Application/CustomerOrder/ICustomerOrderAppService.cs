using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerOrderAppService : IApplicationService
    {
        Task<ListCustomerOrderRs> GetAllOrder();
        Task<GetCustomerOrderRs> GetOrderById(GetCustomerOrderRq rq);
        //Task<GetCustomerOrderRs> GetOrderByCustomerId(GetCustomerOrderRq rq);
        Task<CreateCustomerOrderRs> CreateOrder(CreateCustomerOrderRq rq);
        Task<UpdateCustomerOrderRs> UpdateOrder(UpdateCustomerOrderRq rq);
        Task<DeleteCustomerOrderRs> DeleteOrder(DeleteCustomerOrderRq rq);
    }
}
