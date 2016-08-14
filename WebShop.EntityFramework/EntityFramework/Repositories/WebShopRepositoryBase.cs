using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;

namespace WebShop.EntityFramework.Repositories
{
    public abstract class WebShopRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<WebShopDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected WebShopRepositoryBase(IDbContextProvider<WebShopDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class WebShopRepositoryBase<TEntity> : WebShopRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected WebShopRepositoryBase(IDbContextProvider<WebShopDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
