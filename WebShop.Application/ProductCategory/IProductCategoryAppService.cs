using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductCategoryAppService : IApplicationService
    {
        Task<ListProductCategoryRs> GetAllProductCategory();
        Task<GetProductCategoryRs> GetProductCategory(GetProductCategoryRq rq);
        Task<CreateProductCategoryRs> CreateProductCategory(CreateProductCategoryRq rq);
        Task<UpdateProductCategoryRs> UpdateProductCategory(UpdateProductCategoryRq rq);
        Task<DeleteProductCategoryRs> DeleteProductCategory(DeleteProductCategoryRq rq);
    }
}
