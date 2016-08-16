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
    public class ConfigOptionsViewModel
    {
        private readonly IConfigOptionsAppService _configOptionsAppService;

        public ConfigOptionsViewModel(IConfigOptionsAppService configOptionsAppService)
        {
            _configOptionsAppService = configOptionsAppService;
        }

        public async Task FillDataForModel()
        {
            ListConfigOptions = (await _configOptionsAppService.GetAllConfigOptions()).ConfigOptions;
        }

        public IList<ConfigOptionsDTO> ListConfigOptions { get; set; }
    }
}