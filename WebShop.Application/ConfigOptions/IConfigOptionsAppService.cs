using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IConfigOptionsAppService : IApplicationService
    {
        Task<ListConfigOptionsRs> GetAllConfigOptions();
        Task<GetConfigOptionsRs> GetConfigOption(GetConfigOptionsRq rq);
        Task<CreateConfigOptionsRs> CreateConfigOption(CreateConfigOptionsRq rq);
        Task<UpdateConfigOptionsRs> UpdateConfigOption(UpdateConfigOptionsRq rq);
        Task<DeleteConfigOptionsRs> DeleteConfigOption(DeleteConfigOptionsRq rq);
    }
}
