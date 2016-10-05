using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IConfigOptionsAppService : IApplicationService
    {
        Task<ListConfigOptionsRs> GetAllOptions();
        Task<GetConfigOptionsRs> GetOptionById(GetConfigOptionsRq rq);
        Task<GetConfigOptionsRs> GetOptionByKey(GetConfigOptionsRq rq);
        Task<CreateConfigOptionsRs> CreateOption(CreateConfigOptionsRq rq);
        Task<UpdateConfigOptionsRs> UpdateOption(UpdateConfigOptionsRq rq);
        Task<DeleteConfigOptionsRs> DeleteOption(DeleteConfigOptionsRq rq);
    }
}
