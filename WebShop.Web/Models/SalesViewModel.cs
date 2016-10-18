using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Security;
using WebShop.Application;
using System.Linq;
using Newtonsoft.Json;

namespace WebShop.Web.Models
{
    public class SalesViewModel
    {
        private readonly IProductAppService _productApp;
        private readonly IConfigOptionsAppService _optionApp;
        private readonly IProductCategoryAppService _productCatApp;

        public SalesViewModel(IProductAppService productApp, 
            IProductCategoryAppService productCatApp,
            IConfigOptionsAppService optionApp)
        {
            _productApp = productApp;
            _optionApp = optionApp;
            _productCatApp = productCatApp;
        }

        public async Task GetDataToModel()
        {
            ConfigOptions = (await _optionApp.GetAllConfigOptions()).Options;
            ProductCategories = (await _productCatApp.GetAllCategory()).Categories;
            List<ProductDTO> products = (await _productApp.GetAllProductsAsync()).Products;
            RelatedProducts = products.Where(p => p.CategoryId == 1).ToList();
        }

        public async Task GetProductInCarts(string shoppingCart)
        {
            List<ProductDTO> cartFromClient = JsonConvert.DeserializeObject<List<ProductDTO>>(shoppingCart);
            InCartProducts = (await _productApp.GetAllProductsAsync()).Products
                                                                    .Where(p => cartFromClient.Any(pic => pic.Id == p.Id))
                                                                    .ToList();
            for (int i = 0; i < cartFromClient.Count; i++)
            {
                InCartProducts[i].Quantity = cartFromClient[i].Quantity;
            }
        }

        public MembershipUser User { get; set; }
        public List<ConfigOptionsDTO> ConfigOptions { get; set; }
        public List<ProductCategoryDTO> ProductCategories { get; set; }
        public List<ProductDTO> RelatedProducts { get; set; }
        public List<ProductDTO> InCartProducts { get; set; }
    }
}