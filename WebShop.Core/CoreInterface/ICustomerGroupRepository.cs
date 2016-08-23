using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface ICustomerGroupRepository : IRepository<CustomerGroup, int>
    {
        // Declare custom action with database
        Task<CustomerGroup> GetGroupByNameAsync(string GroupName);
    }
}
