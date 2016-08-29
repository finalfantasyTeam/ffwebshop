using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductCategoryAppService : IApplicationService
    {
        Task<ListProductCategoryRs> GetAllCategory();
        Task<GetProductCategoryRs> GetCategoryById(GetProductCategoryRq rq);
        Task<GetProductCategoryRs> GetCategoryByName(GetProductCategoryRq rq);
        Task<CreateProductCategoryRs> CreateCategory(CreateProductCategoryRq rq);
        Task<UpdateProductCategoryRs> UpdateCategory(UpdateProductCategoryRq rq);
        Task<DeleteProductCategoryRs> DeleteCategory(DeleteProductCategoryRq rq);
    }
}
