using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<ListCustomerRs> GetAllCustomer();
        Task<GetCustomerRs> GetCustomerById(GetCustomerRq rq);
        Task<GetCustomerRs> GetCustomerByFirstName(GetCustomerRq rq);
        Task<CreateCustomerRs> CreateCustomer(CreateCustomerRq rq);
        Task<UpdateCustomerRs> UpdateCustomer(UpdateCustomerRq rq);
        Task<DeleteCustomerRs> DeleteCustomer(DeleteCustomerRq rq);
    }
}
