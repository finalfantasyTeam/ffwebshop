using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Security;
using WebShop.Application;
using System.Linq;

namespace WebShop.Web.Models
{
    public class ProductPageViewModel
    {
        private readonly IProductAppService _productApp;
        private readonly IConfigOptionsAppService _optionApp;
        private readonly IProductCategoryAppService _productCatApp;
        private readonly IProductManufactoryAppService _productManuApp;

        public ProductPageViewModel(IProductAppService productApp, 
            IProductCategoryAppService productCatApp,
            IProductManufactoryAppService productManuApp,
            IConfigOptionsAppService optionApp)
        {
            _productApp = productApp;
            _optionApp = optionApp;
            _productCatApp = productCatApp;
            _productManuApp = productManuApp;
        }

        public async Task GetDataToModel()
        {
            ConfigOptions = (await _optionApp.GetAllConfigOptions()).Options;
            ProductCategories = (await _productCatApp.GetAllCategory()).Categories;
            ProductManufatories = (await _productManuApp.GetAllManufactory()).Manufactories;
        }

        public async Task GetProduct(int id)
        {
            GetProductRq rq = new GetProductRq()
            { Id = id };
            Product = (await _productApp.GetProductById(rq)).Product;

            List<ProductDTO> products = (await _productApp.GetAllProductsAsync()).Products;
            RelatedProducts = products.Where(p => p.CategoryId == Product.CategoryId).ToList();
            SaleOffProducts = products.Where(p => p.Discount.Value > 0).ToList();
        }

        public async Task GetProductByCategory(int id)
        {
            GetProductCategoryRq rq = new GetProductCategoryRq()
            { Id = id };
            CurrentCategory = (await _productCatApp.GetCategoryById(rq)).Category;

            List<ProductDTO> products = (await _productApp.GetAllProductsAsync()).Products;
            ProductInCategory = products.Where(p => p.CategoryId == id).ToList();
        }

        public MembershipUser User { get; set; }
        public ProductDTO Product { get; set; }
        public ProductCategoryDTO CurrentCategory { get; set; }
        public List<ConfigOptionsDTO> ConfigOptions { get; set; }
        public List<ProductCategoryDTO> ProductCategories { get; set; }
        public List<ProductManufactoryDTO> ProductManufatories { get; set; }
        public List<ProductDTO> RelatedProducts { get; set; }
        public List<ProductDTO> SaleOffProducts { get; set; }
        public List<ProductDTO> ProductInCategory { get; set; }
    }
}