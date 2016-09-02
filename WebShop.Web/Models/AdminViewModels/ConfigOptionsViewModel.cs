using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ConfigOptionsViewModel
    {
        private readonly IConfigOptionsAppService _OptionAppService;

        public ConfigOptionsViewModel()
        {
        }

        public ConfigOptionsViewModel(IConfigOptionsAppService OptionAppService)
        {
            _OptionAppService = OptionAppService;
        }

        public async Task FillDataForModel()
        {
            ListConfigOptions = (await _OptionAppService.GetAllOptions()).Options;
        }

        public async Task GetConfigOptions(int id)
        {
            GetConfigOptionsRq rq = new GetConfigOptionsRq()
            { Id = id };
            ConfigOptions = (await _OptionAppService.GetOptionById(rq)).Option;
        }

        public async Task CreateNewConfigOptions()
        {
            CreateConfigOptionsRq rq = new CreateConfigOptionsRq()
            { Option = ConfigOptions };
            ConfigOptions = (await _OptionAppService.CreateOption(rq)).Option;
        }

        public async Task UpdateConfigOptions()
        {
            UpdateConfigOptionsRq rq = new UpdateConfigOptionsRq()
            { Option = ConfigOptions };
            ConfigOptions = (await _OptionAppService.UpdateOption(rq)).Option;
        }

        public async Task DeleteConfigOptions()
        {
            DeleteConfigOptionsRq rq = new DeleteConfigOptionsRq()
            { Option = ConfigOptions };
            await _OptionAppService.DeleteOption(rq);
        }
        public IList<ConfigOptionsDTO> ListConfigOptions { get; set; }
        public ConfigOptionsDTO ConfigOptions { get; set; }
    }
}