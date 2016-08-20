using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IUsersAppService : IApplicationService
    {
        Task<ListUsersRs> GetAllUsers();
        Task<GetUsersRs> GetUser(GetUsersRq rq);
        Task<CreateUsersRs> CreateUser(CreateUsersRq rq);
        Task<UpdateUsersRs> UpdateUser(UpdateUsersRq rq);
        Task<DeleteUsersRs> DeleteUser(DeleteUsersRq rq);
    }
}
