using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IInvoiceRepository : IRepository<Invoice, int>
    {
        // Declare custom action with database
        Task<Invoice> GetInvoiceByCustomerIdAsync(int CustomerId);
    }
}
