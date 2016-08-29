using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ProductMetaRepository : WebShopRepositoryBase<Core.ProductMeta>, IProductMetaRepository
    {
        public ProductMetaRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.ProductMeta> GetMetaByKeyAsync(string MetaKey)
        {
            return await SingleAsync(m => m.MetaKey.Contains(MetaKey));
        }
    }
}
