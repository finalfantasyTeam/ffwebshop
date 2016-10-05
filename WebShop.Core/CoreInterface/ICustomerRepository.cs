using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        // Declare custom action with database
        Task<Customer> GetCustomerByFirstNameAsync(string GroupName);
    }
}
