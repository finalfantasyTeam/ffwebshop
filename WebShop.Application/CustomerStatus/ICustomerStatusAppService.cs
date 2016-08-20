using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerStatusAppService : IApplicationService
    {
        Task<ListCustomerStatusRs> GetAllCustomerStatus();
        Task<GetCustomerStatusRs> GetCustomerStatus(GetCustomerStatusRq rq);
        Task<CreateCustomerStatusRs> CreateCustomerStatus(CreateCustomerStatusRq rq);
        Task<UpdateCustomerStatusRs> UpdateCustomerStatus(UpdateCustomerStatusRq rq);
        Task<DeleteCustomerStatusRs> DeleteCustomerStatus(DeleteCustomerStatusRq rq);
    }
}
