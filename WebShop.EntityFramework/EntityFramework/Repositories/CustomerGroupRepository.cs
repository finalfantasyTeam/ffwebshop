using Abp.EntityFramework;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class CustomerGroupRepository : WebShopRepositoryBase<Core.CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.CustomerGroup> GetGroupByNameAsync(string GroupName)
        {
            return await SingleAsync(m => m.Name.Contains(GroupName));
        }
    }
}
