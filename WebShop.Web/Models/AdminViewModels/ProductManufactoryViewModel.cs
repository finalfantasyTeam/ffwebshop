using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ProductManufactoryViewModel
    {
        private readonly IProductManufactoryAppService _manufactoryAppService;

        public ProductManufactoryViewModel()
        {
        }

        public ProductManufactoryViewModel(IProductManufactoryAppService manufactoryAppService)
        {
            _manufactoryAppService = manufactoryAppService;
        }

        public async Task FillDataForModel()
        {
            ListProductManufactory = (await _manufactoryAppService.GetAllManufactory()).Manufactories;
        }

        public async Task GetProductManufactory(int id)
        {
            GetProductManufactoryRq rq = new GetProductManufactoryRq()
            { Id = id };
            ProductManufactory = (await _manufactoryAppService.GetManufactoryById(rq)).Manufactory;
        }

        public async Task CreateNewProductManufactory()
        {
            CreateProductManufactoryRq rq = new CreateProductManufactoryRq()
            { Manufactory = ProductManufactory };
            ProductManufactory = (await _manufactoryAppService.CreateManufactory(rq)).Manufactory;
        }

        public async Task UpdateProductManufactory()
        {
            UpdateProductManufactoryRq rq = new UpdateProductManufactoryRq()
            { Manufactory = ProductManufactory };
            ProductManufactory = (await _manufactoryAppService.UpdateManufactory(rq)).Manufactory;
        }

        public async Task DeleteProductManufactory()
        {
            DeleteProductManufactoryRq rq = new DeleteProductManufactoryRq()
            { Manufactory = ProductManufactory };
            await _manufactoryAppService.DeleteManufactory(rq);
        }
        public IList<ProductManufactoryDTO> ListProductManufactory { get; set; }
        public ProductManufactoryDTO ProductManufactory { get; set; }
    }
}