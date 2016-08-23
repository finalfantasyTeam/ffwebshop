using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerStatusAppService : IApplicationService
    {
        Task<ListCustomerStatusRs> GetAllStatus();
        Task<GetCustomerStatusRs> GetStatusById(GetCustomerStatusRq rq);
        Task<CreateCustomerStatusRs> CreateStatus(CreateCustomerStatusRq rq);
        Task<UpdateCustomerStatusRs> UpdateStatus(UpdateCustomerStatusRq rq);
        Task<DeleteCustomerStatusRs> DeleteStatus(DeleteCustomerStatusRq rq);
    }
}
