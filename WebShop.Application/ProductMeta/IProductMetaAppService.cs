using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductMetaAppService : IApplicationService
    {
        Task<ListProductMetaRs> GetAllMeta();
        Task<GetProductMetaRs> GetMetaById(GetProductMetaRq rq);
        Task<GetProductMetaRs> GetMetaByKey(GetProductMetaRq rq);
        Task<CreateProductMetaRs> CreateMeta(CreateProductMetaRq rq);
        Task<UpdateProductMetaRs> UpdateMeta(UpdateProductMetaRq rq);
        Task<DeleteProductMetaRs> DeleteMeta(DeleteProductMetaRq rq);
    }
}
