using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ProductStatusViewModel
    {
        private readonly IProductStatusAppService _StatusAppService;

        public ProductStatusViewModel()
        {
        }

        public ProductStatusViewModel(IProductStatusAppService StatusAppService)
        {
            _StatusAppService = StatusAppService;
        }

        public async Task FillDataForModel()
        {
            ListProductStatus = (await _StatusAppService.GetAllStatus()).Statuses;
        }

        public async Task GetProductStatus(int id)
        {
            GetProductStatusRq rq = new GetProductStatusRq()
            { Id = id };
            ProductStatus = (await _StatusAppService.GetStatusById(rq)).Status;
        }

        public async Task CreateNewProductStatus()
        {
            CreateProductStatusRq rq = new CreateProductStatusRq()
            { Status = ProductStatus };
            ProductStatus = (await _StatusAppService.CreateStatus(rq)).Status;
        }

        public async Task UpdateProductStatus()
        {
            UpdateProductStatusRq rq = new UpdateProductStatusRq()
            { Status = ProductStatus };
            ProductStatus = (await _StatusAppService.UpdateStatus(rq)).Status;
        }

        public async Task DeleteProductStatus()
        {
            DeleteProductStatusRq rq = new DeleteProductStatusRq()
            { Status = ProductStatus };
            await _StatusAppService.DeleteStatus(rq);
        }
        public IList<ProductStatusDTO> ListProductStatus { get; set; }
        public ProductStatusDTO ProductStatus { get; set; }
    }
}