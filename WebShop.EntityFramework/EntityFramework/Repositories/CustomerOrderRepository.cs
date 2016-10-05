using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class CustomerOrderRepository : WebShopRepositoryBase<Core.CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        //public async Task<Core.CustomerOrder> GetOrderByCustomerIdAsync(int CustomerId)
        //{
        //    return await SingleAsync(m => m.CustomerId.Contains(CustomerId));
        //}
    }
}
