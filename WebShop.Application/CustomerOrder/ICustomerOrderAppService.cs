using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerOrderAppService : IApplicationService
    {
        Task<ListCustomerOrderRs> GetAllCustomerOrder();
        Task<GetCustomerOrderRs> GetCustomerOrder(GetCustomerOrderRq rq);
        Task<CreateCustomerOrderRs> CreateCustomerOrder(CreateCustomerOrderRq rq);
        Task<UpdateCustomerOrderRs> UpdateCustomerOrder(UpdateCustomerOrderRq rq);
        Task<DeleteCustomerOrderRs> DeleteCustomerOrder(DeleteCustomerOrderRq rq);
    }
}
