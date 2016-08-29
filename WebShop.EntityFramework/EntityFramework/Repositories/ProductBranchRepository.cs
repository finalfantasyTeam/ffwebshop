using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ProductBranchRepository : WebShopRepositoryBase<Core.ProductBranch>, IProductBranchRepository
    {
        public ProductBranchRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.ProductBranch> GetBranchByNameAsync(string BranchName)
        {
            return await SingleAsync(m => m.Name.Contains(BranchName));
        }
    }
}
