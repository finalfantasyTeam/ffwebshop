using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IProductBranchAppService : IApplicationService
    {
        Task<ListProductBranchRs> GetAllBranch();
        Task<GetProductBranchRs> GetBranchById(GetProductBranchRq rq);
        Task<CreateProductBranchRs> CreateBranch(CreateProductBranchRq rq);
        Task<UpdateProductBranchRs> UpdateBranch(UpdateProductBranchRq rq);
        Task<DeleteProductBranchRs> DeleteBranch(DeleteProductBranchRq rq);
    }
}
