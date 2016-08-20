using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductMetaAppService : IApplicationService
    {
        Task<ListProductMetaRs> GetAllProductMeta();
        Task<GetProductMetaRs> GetProductMeta(GetProductMetaRq rq);
        Task<CreateProductMetaRs> CreateProductMeta(CreateProductMetaRq rq);
        Task<UpdateProductMetaRs> UpdateProductMeta(UpdateProductMetaRq rq);
        Task<DeleteProductMetaRs> DeleteProductMeta(DeleteProductMetaRq rq);
    }
}
