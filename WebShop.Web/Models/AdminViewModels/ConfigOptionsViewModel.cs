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

        public ConfigOptionsViewModel()
        {
        }

        public ConfigOptionsViewModel(IConfigOptionsAppService configOptionsAppService)
        {
            _configOptionsAppService = configOptionsAppService;
        }

        public async Task FillDataForModel()
        {
            ListConfigOptions = (await _configOptionsAppService.GetAllConfigOptions()).ConfigOptions;
        }

        public async Task GetConfigOptions(int id)
        {
            GetConfigOptionsRq rq = new GetConfigOptionsRq()
            { Id = id };
            ConfigOptions = (await _configOptionsAppService.GetConfigOption(rq)).ConfigOption;
        }

        public ConfigOptionsDTO ConfigOptions { get; set; }
        public IList<ConfigOptionsDTO> ListConfigOptions { get; set; }
    }
}