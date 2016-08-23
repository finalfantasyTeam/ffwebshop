using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class CustomerStatusRepository : WebShopRepositoryBase<Core.CustomerStatus>, ICustomerStatusRepository
    {
        public CustomerStatusRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.CustomerStatus> GetStatusByNameAsync(string StatusName)
        {
            return await SingleAsync(m => m.Name.Contains(StatusName));
        }
    }
}
