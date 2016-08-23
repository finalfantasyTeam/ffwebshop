using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface ICustomerGroupAppService : IApplicationService
    {
        Task<ListCustomerGroupRs> GetAllGroup();
        Task<GetCustomerGroupRs> GetGroupById(GetCustomerGroupRq rq);
        Task<CreateCustomerGroupRs> CreateGroup(CreateCustomerGroupRq rq);
        Task<UpdateCustomerGroupRs> UpdateGroup(UpdateCustomerGroupRq rq);
        Task<DeleteCustomerGroupRs> DeleteGroup(DeleteCustomerGroupRq rq);
    }
}
