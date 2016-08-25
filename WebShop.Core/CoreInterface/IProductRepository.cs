using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IProductRepository : IRepository<Product, int>
    {
        // Declare custom action with database
        Task<Product> GetProductByNameAsync(string ProductName);
    }
}
