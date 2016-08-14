﻿using Abp.EntityFramework;
using System.Data.Entity;

namespace WebShop.EntityFramework
{
    public class WebShopDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity
        public virtual IDbSet<Core.ProductManufactory> ProductManufactories { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public WebShopDbContext()
            : base("Default")
        {
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WebShopDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WebShopDbContext since ABP automatically handles it.
         */
        public WebShopDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
