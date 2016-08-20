using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<ListCustomerRs> GetAllCustomer();
        Task<GetCustomerRs> GetCustomer(GetCustomerRq rq);
        Task<CreateCustomerRs> CreateCustomer(CreateCustomerRq rq);
        Task<UpdateCustomerRs> UpdateCustomer(UpdateCustomerRq rq);
        Task<DeleteCustomerRs> DeleteCustomer(DeleteCustomerRq rq);
    }
}
