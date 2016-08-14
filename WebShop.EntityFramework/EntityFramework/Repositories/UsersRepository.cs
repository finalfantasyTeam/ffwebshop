using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;
using Abp.Domain.Repositories;

namespace WebShop.EntityFramework.Repositories
{
    public class UsersRepository : WebShopRepositoryBase<Core.Users, Guid>, IUsersRepository
    {
        public UsersRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }
    }
}
