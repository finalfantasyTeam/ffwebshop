using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ProductCategoryRepository : WebShopRepositoryBase<Core.ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }
    }
}
