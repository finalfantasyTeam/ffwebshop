using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductStatusAppService : IApplicationService
    {
        Task<ListProductStatusRs> GetAllStatus();
        Task<GetProductStatusRs> GetStatusById(GetProductStatusRq rq);
        Task<GetProductStatusRs> GetStatusByName(GetProductStatusRq rq);
        Task<CreateProductStatusRs> CreateStatus(CreateProductStatusRq rq);
        Task<UpdateProductStatusRs> UpdateStatus(UpdateProductStatusRq rq);
        Task<DeleteProductStatusRs> DeleteStatus(DeleteProductStatusRq rq);
    }
}
