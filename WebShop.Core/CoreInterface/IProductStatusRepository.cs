using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IProductStatusRepository : IRepository<ProductStatus, int>
    {
        // Declare custom action with database
        Task<ProductStatus> GetStatusByNameAsync(string StatusName);
    }
}
