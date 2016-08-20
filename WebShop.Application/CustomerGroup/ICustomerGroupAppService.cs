using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerGroupAppService : IApplicationService
    {
        Task<ListCustomerGroupRs> GetAllCustomerGroup();
        Task<GetCustomerGroupRs> GetCustomerGroup(GetCustomerGroupRq rq);
        Task<CreateCustomerGroupRs> CreateCustomerGroup(CreateCustomerGroupRq rq);
        Task<UpdateCustomerGroupRs> UpdateCustomerGroup(UpdateCustomerGroupRq rq);
        Task<DeleteCustomerGroupRs> DeleteCustomerGroup(DeleteCustomerGroupRq rq);
    }
}
