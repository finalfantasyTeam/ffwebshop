using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ProductBranchViewModel
    {
        private readonly IProductBranchAppService _BranchAppService;

        public ProductBranchViewModel()
        {
        }

        public ProductBranchViewModel(IProductBranchAppService BranchAppService)
        {
            _BranchAppService = BranchAppService;
        }

        public async Task FillDataForModel()
        {
            ListProductBranch = (await _BranchAppService.GetAllBranch()).Branches;
        }

        public async Task GetProductBranch(int id)
        {
            GetProductBranchRq rq = new GetProductBranchRq()
            { Id = id };
            ProductBranch = (await _BranchAppService.GetBranchById(rq)).Branch;
        }

        public async Task CreateNewProductBranch()
        {
            CreateProductBranchRq rq = new CreateProductBranchRq()
            { Branch = ProductBranch };
            ProductBranch = (await _BranchAppService.CreateBranch(rq)).Branch;
        }

        public async Task UpdateProductBranch()
        {
            UpdateProductBranchRq rq = new UpdateProductBranchRq()
            { Branch = ProductBranch };
            ProductBranch = (await _BranchAppService.UpdateBranch(rq)).Branch;
        }

        public async Task DeleteProductBranch()
        {
            DeleteProductBranchRq rq = new DeleteProductBranchRq()
            { Branch = ProductBranch };
            await _BranchAppService.DeleteBranch(rq);
        }
        public IList<ProductBranchDTO> ListProductBranch { get; set; }
        public ProductBranchDTO ProductBranch { get; set; }
    }
}