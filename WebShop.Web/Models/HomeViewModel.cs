using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Security;
using WebShop.Application;
using System.Linq;

namespace WebShop.Web.Models
{
    public class HomeViewModel
    {
        private readonly IProductAppService _productApp;
        private readonly IConfigOptionsAppService _optionApp;

        public HomeViewModel(IProductAppService productApp, IConfigOptionsAppService optionApp)
        {
            _productApp = productApp;
            _optionApp = optionApp;
        }

        public async Task GetDataToModel()
        {
            ListProduct = _productApp.GetAllProducts().Products;
            ConfigOptions = (await _optionApp.GetAllConfigOptions()).Options;

            BestSellProducts = ListProduct.Take(8).ToList();
            NewProducts = ListProduct.Skip(2).Take(8).ToList();
            SaleOffProducts = ListProduct.Skip(4).Take(8).ToList(); 
        }

        public MembershipUser User { get; set; }
        public List<ConfigOptionsDTO> ConfigOptions { get; set; }
        public List<ProductDTO> ListProduct { get; set; }
        public List<ProductDTO> BestSellProducts { get; set; }
        public List<ProductDTO> NewProducts { get; set; }
        public List<ProductDTO> SaleOffProducts { get; set; }
    }
}