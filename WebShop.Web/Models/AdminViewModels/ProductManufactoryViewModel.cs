using Abp.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Application;
using WebShop.Core;


namespace WebShop.Web.Models
{
    public class ProductManufactoryViewModel
    {
        private readonly IProductManufactoryRepository _manufactoryRepo;
        private readonly IProductManufactoryAppService _manufactoryAppService;
        private readonly IDbContextProvider<EntityFramework.WebShopDbContext> _dbContextProvider;

        public ProductManufactoryViewModel()
        {
        }

        public async Task FillDataForModel()
        {
            ListProductManufactory = (await _manufactoryAppService.GetAllManufactory()).Manufactories;
        }

        public IList<ProductManufactoryDTO> ListProductManufactory { get; set; }
    }
}