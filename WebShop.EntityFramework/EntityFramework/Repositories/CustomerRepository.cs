using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class CustomerRepository : WebShopRepositoryBase<Core.Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.Customer> GetCustomerByFirstNameAsync(string GroupName)
        {
            return await SingleAsync(m => m.FirstName.Contains(GroupName));
        }
    }
}
