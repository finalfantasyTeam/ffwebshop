using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface ICustomerStatusRepository : IRepository<CustomerStatus, int>
    {
        // Declare custom action with database
        Task<CustomerStatus> GetStatusByNameAsync(string StatusName);
    }
}
