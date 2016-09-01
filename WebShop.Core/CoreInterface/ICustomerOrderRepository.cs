using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface ICustomerOrderRepository : IRepository<CustomerOrder, int>
    {
        // Declare custom action with database
        //Task<CustomerOrder> GetOrderByCustomerIdAsync(int CustomerId);
    }
}
