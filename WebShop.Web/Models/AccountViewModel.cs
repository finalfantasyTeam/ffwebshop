using Abp.Dependency;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WebShop.Application;
using WebShop.Core;
using WebShop.EntityFramework.Repositories;

namespace WebShop.Web.Models
{
    public class AccountViewModel
    {
        private readonly IUsersAppService _usersAppService;
    }
}