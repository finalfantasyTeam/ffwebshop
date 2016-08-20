using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductStatusAppService : IApplicationService
    {
        Task<ListProductStatusRs> GetAllProductStatus();
        Task<GetProductStatusRs> GetProductStatus(GetProductStatusRq rq);
        Task<CreateProductStatusRs> CreateProductStatus(CreateProductStatusRq rq);
        Task<UpdateProductStatusRs> UpdateProductStatus(UpdateProductStatusRq rq);
        Task<DeleteProductStatusRs> DeleteProductStatus(DeleteProductStatusRq rq);
    }
}
