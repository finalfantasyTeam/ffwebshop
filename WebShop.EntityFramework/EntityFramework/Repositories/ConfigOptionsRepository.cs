using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ConfigOptionsRepository : WebShopRepositoryBase<Core.ConfigOptions>, IConfigOptionsRepository
    {
        public ConfigOptionsRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.ConfigOptions> GetOptionByKeyAsync(string OptionKey)
        {
            return await SingleAsync(m => m.OptionKey.Contains(OptionKey));
        }
    }
}
