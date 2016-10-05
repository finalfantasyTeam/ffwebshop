using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ProductViewModel
    {
        private readonly IProductAppService _ProductAppService;

        public ProductViewModel(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
            Product = new ProductDTO();
            ListProduct = new List<ProductDTO>();
        }

        public void FillDataForModel()
        {
            ListProduct = _ProductAppService.GetAllProducts().Products;
        }

        public async Task GetProduct(int id)
        {
            GetProductRq rq = new GetProductRq()
            { Id = id };
            Product = (await _ProductAppService.GetProductById(rq)).Product;
        }

        public async Task CreateNewProduct()
        {
            CreateProductRq rq = new CreateProductRq()
            { Product = Product };
            Product = (await _ProductAppService.CreateProduct(rq)).Product;
        }

        public async Task UpdateProduct()
        {
            UpdateProductRq rq = new UpdateProductRq()
            { Product = Product };
            Product = (await _ProductAppService.UpdateProduct(rq)).Product;
        }

        public async Task DeleteProduct()
        {
            DeleteProductRq rq = new DeleteProductRq()
            { Product = Product };
            await _ProductAppService.DeleteProduct(rq);
        }

        public IList<ProductDTO> ListProduct { get; set; }
        public ProductDTO Product { get; set; }
    }
}