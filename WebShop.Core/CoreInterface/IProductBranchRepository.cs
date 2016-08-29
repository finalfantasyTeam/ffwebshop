using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IProductBranchRepository : IRepository<ProductBranch, int>
    {
        // Declare custom action with database
        Task<ProductBranch> GetBranchByNameAsync(string BranchName);
    }
}
