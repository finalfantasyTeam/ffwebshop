using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        private readonly IProductCategoryAppService _CategoryAppService;

        public ProductCategoryViewModel()
        {
        }

        public ProductCategoryViewModel(IProductCategoryAppService CategoryAppService)
        {
            _CategoryAppService = CategoryAppService;
        }

        public async Task FillDataForModel()
        {
            ListProductCategory = (await _CategoryAppService.GetAllCategory()).Categories;
        }

        public async Task GetProductCategory(int id)
        {
            GetProductCategoryRq rq = new GetProductCategoryRq()
            { Id = id };
            ProductCategory = (await _CategoryAppService.GetCategoryById(rq)).Category;
        }

        public async Task CreateNewProductCategory()
        {
            CreateProductCategoryRq rq = new CreateProductCategoryRq()
            { Category = ProductCategory };
            ProductCategory = (await _CategoryAppService.CreateCategory(rq)).Category;
        }

        public async Task UpdateProductCategory()
        {
            UpdateProductCategoryRq rq = new UpdateProductCategoryRq()
            { Category = ProductCategory };
            ProductCategory = (await _CategoryAppService.UpdateCategory(rq)).Category;
        }

        public async Task DeleteProductCategory()
        {
            DeleteProductCategoryRq rq = new DeleteProductCategoryRq()
            { Category = ProductCategory };
            await _CategoryAppService.DeleteCategory(rq);
        }
        public IList<ProductCategoryDTO> ListProductCategory { get; set; }
        public ProductCategoryDTO ProductCategory { get; set; }
    }
}