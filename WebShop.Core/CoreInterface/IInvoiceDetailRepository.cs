﻿using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace WebShop.Core
{
    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail, int>
    {
    }
}
