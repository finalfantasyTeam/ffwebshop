using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductManufactoryAppService : IApplicationService
    {
        Task<ListProductManufactoryRs> GetAllManufactory();
        Task<GetProductManufactoryRs> GetManufactoryById(GetProductManufactoryRq rq);
        Task<GetProductManufactoryRs> GetManufactoryByName(GetProductManufactoryRq rq);
        Task<CreateProductManufactoryRs> CreateManufactory(CreateProductManufactoryRq rq);
        Task<UpdateProductManufactoryRs> UpdateManufactory(UpdateProductManufactoryRq rq);
        Task<DeleteProductManufactoryRs> DeleteManufactory(DeleteProductManufactoryRq rq);
    }
}
