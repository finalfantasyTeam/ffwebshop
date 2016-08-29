using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class ProductMetaViewModel
    {
        private readonly IProductMetaAppService _MetaAppService;

        public ProductMetaViewModel(IProductMetaAppService MetaAppService)
        {
            _MetaAppService = MetaAppService;
        }

        public async Task FillDataForModel()
        {
            ListProductMeta = (await _MetaAppService.GetAllMeta()).Metas;
        }

        public async Task GetProductMeta(int id)
        {
            GetProductMetaRq rq = new GetProductMetaRq()
            { Id = id };
            ProductMeta = (await _MetaAppService.GetMetaById(rq)).Meta;
        }

        public async Task CreateNewProductMeta()
        {
            CreateProductMetaRq rq = new CreateProductMetaRq()
            { Meta = ProductMeta };
            ProductMeta = (await _MetaAppService.CreateMeta(rq)).Meta;
        }

        public async Task UpdateProductMeta()
        {
            UpdateProductMetaRq rq = new UpdateProductMetaRq()
            { Meta = ProductMeta };
            ProductMeta = (await _MetaAppService.UpdateMeta(rq)).Meta;
        }

        public async Task DeleteProductMeta()
        {
            DeleteProductMetaRq rq = new DeleteProductMetaRq()
            { Meta = ProductMeta };
            await _MetaAppService.DeleteMeta(rq);
        }

        public IList<ProductMetaDTO> ListProductMeta { get; set; }
        public ProductMetaDTO ProductMeta { get; set; }
    }
}