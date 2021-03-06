﻿using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.EntityFramework.Repositories
{
    public class InvoiceDetailRepository : WebShopRepositoryBase<Core.InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(IDbContextProvider<WebShopDbContext> dbContextProvider) 
            : base(dbContextProvider)
        { }
    }
}
