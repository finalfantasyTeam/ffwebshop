using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class InvoiceRepository : WebShopRepositoryBase<Core.Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.Invoice> GetInvoiceByCustomerIdAsync(int CustomerId)
        {
            return await SingleAsync(m => m.CustomerId == CustomerId);
        }
    }
}
