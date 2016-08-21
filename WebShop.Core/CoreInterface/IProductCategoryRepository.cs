using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        // Declare custom action with database
        Task<ProductCategory> GetCategoryByNameAsync(string CategoryName);
    }
}
