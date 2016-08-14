using Abp.Dependency;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WebShop.Application;
using WebShop.Core;
using WebShop.EntityFramework.Repositories;

namespace WebShop.Web.Models
{
    public class ProductManufactoryViewModel
    {
        private readonly IProductManufactoryAppService _manufactoryAppService;

        public ProductManufactoryViewModel(IProductManufactoryAppService manufactoryAppService)
        {
            _manufactoryAppService = manufactoryAppService;
        }

        public async Task FillDataForModel()
        {
            ListProductManufactory = (await _manufactoryAppService.GetAllManufactory()).Manufactories;
        }

        public IList<ProductManufactoryDTO> ListProductManufactory { get; set; }
    }
}