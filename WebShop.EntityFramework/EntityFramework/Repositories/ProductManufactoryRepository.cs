using Abp.EntityFramework;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ProductManufactoryRepository : WebShopRepositoryBase<Core.ProductManufactory>, IProductManufactoryRepository
    {
        public ProductManufactoryRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.ProductManufactory> GetManufactoryByNameAsync(string manufactoryName)
        {
            return await SingleAsync(m => m.Name.Contains(manufactoryName));
        }
    }
}
