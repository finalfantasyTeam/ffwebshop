using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductAppService : IApplicationService
    {
        ListProductRs GetAllProducts();
        Task<ListProductRs> GetAllProductsAsync();
        Task<GetProductRs> GetProductById(GetProductRq rq);
        Task<GetProductRs> GetProductByName(GetProductRq rq);
        Task<CreateProductRs> CreateProduct(CreateProductRq rq);
        Task<UpdateProductRs> UpdateProduct(UpdateProductRq rq);
        Task<DeleteProductRs> DeleteProduct(DeleteProductRq rq);
    }
}
