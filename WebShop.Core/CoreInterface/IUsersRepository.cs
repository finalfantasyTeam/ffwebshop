using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;
using System;

namespace WebShop.Core
{
    public interface IUsersRepository : IRepository<Users, Guid>
    {
    }
}
