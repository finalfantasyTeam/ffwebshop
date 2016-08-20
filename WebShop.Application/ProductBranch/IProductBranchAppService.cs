using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductBranchAppService : IApplicationService
    {
        Task<ListProductBranchRs> GetAllProductBranch();
        Task<GetProductBranchRs> GetProductBranch(GetProductBranchRq rq);
        Task<CreateProductBranchRs> CreateProductBranch(CreateProductBranchRq rq);
        Task<UpdateProductBranchRs> UpdateProductBranch(UpdateProductBranchRq rq);
        Task<DeleteProductBranchRs> DeleteProductBranch(DeleteProductBranchRq rq);
    }
}
