﻿using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class ProductRepository : WebShopRepositoryBase<Core.Product>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }

        // Implement custom data access function here
        public async Task<Core.Product> GetProductByNameAsync(string ProductName)
        {
            return await SingleAsync(m => m.Name.Contains(ProductName));
        }
    }
}
