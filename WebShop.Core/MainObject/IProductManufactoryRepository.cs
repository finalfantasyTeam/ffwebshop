using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IProductManufactoryRepository : IRepository<ProductManufactory, int>
    {
        // Declare custom action with database
        Task<ProductManufactory> GetManufactoryByName(string manufactoryName);
    }
}
