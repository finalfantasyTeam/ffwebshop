using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ProductManufactoryRepository : WebShopRepositoryBase<WebShop.Core.ProductManufactory>, IProductManufactoryRepository
    {
        public ProductManufactoryRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<WebShop.Core.ProductManufactory> GetManufactoryByName(string manufactoryName)
        {
            return await SingleAsync(m => m.Name.Contains(manufactoryName));
        }
    }
}
