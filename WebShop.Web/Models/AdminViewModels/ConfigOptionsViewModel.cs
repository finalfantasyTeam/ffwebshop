using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Application;

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
            ListConfigOptions = (await _configOptionsAppService.GetAllConfigOptions()).Options;
        }

        public async Task GetConfigOptions(int id)
        {
            GetConfigOptionsRq rq = new GetConfigOptionsRq()
            { Id = id };
            ConfigOptions = (await _configOptionsAppService.GetConfigOption(rq)).Option;
        }

        public ConfigOptionsDTO ConfigOptions { get; set; }
        public IList<ConfigOptionsDTO> ListConfigOptions { get; set; }
    }
}