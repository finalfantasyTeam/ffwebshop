using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class OrderDetailRepository : WebShopRepositoryBase<Core.OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }
    }
}
