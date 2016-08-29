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

        public async Task GetConfigOptions(int id)
        {
            GetConfigOptionsRq rq = new GetConfigOptionsRq()
            { Id = id };
            ConfigOptions = (await _configOptionsAppService.GetConfigOption(rq)).ConfigOption;
        }

        public async Task CreateNewConfigOptions()
        {
            CreateConfigOptionsRq rq = new CreateConfigOptionsRq()
            { ConfigOption = ConfigOptions };
            ConfigOptions = (await _configOptionsAppService.CreateConfigOption(rq)).ConfigOption;
        }

        public async Task UpdateConfigOptions()
        {
            UpdateConfigOptionsRq rq = new UpdateConfigOptionsRq()
            { ConfigOption = ConfigOptions };
            ConfigOptions = (await _configOptionsAppService.UpdateConfigOption(rq)).ConfigOption;
        }

        public async Task DeleteConfigOptions()
        {
            DeleteConfigOptionsRq rq = new DeleteConfigOptionsRq()
            { ConfigOption = ConfigOptions };
            await _configOptionsAppService.DeleteConfigOption(rq);
        }

        public ConfigOptionsDTO ConfigOptions { get; set; }
        public IList<ConfigOptionsDTO> ListConfigOptions { get; set; }
    }
}