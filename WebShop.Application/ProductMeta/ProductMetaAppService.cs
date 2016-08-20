using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductMetaAppService : IProductMetaAppService
    {
        private readonly IProductMetaRepository _productMetaRepository;

        public ProductMetaAppService(IProductMetaRepository productMetaRepository)
        {
            _productMetaRepository = productMetaRepository;
            Mapper.CreateMap<ProductMeta, ProductMetaDTO>();
            Mapper.CreateMap<ProductMetaDTO, ProductMeta>();
        }

        public async Task<ListProductMetaRs> GetAllProductMeta()
        {
            try
            {
                List<ProductMeta> productMeta = await _productMetaRepository.GetAllListAsync();
                return new ListProductMetaRs()
                {
                    ProductMetas = productMeta.MapTo<List<ProductMetaDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductMetaRs> GetProductMeta(GetProductMetaRq rq)
        {
            ProductMeta productMeta = await _productMetaRepository.GetAsync(rq.Id);

            return new GetProductMetaRs()
            {
                ProductMeta = productMeta.MapTo<ProductMetaDTO>()
            };
        }

        public async Task<CreateProductMetaRs> CreateProductMeta(CreateProductMetaRq rq)
        {
            try
            {
                ProductMeta insertProductMeta = rq.ProductMeta.MapTo<ProductMeta>();
                insertProductMeta = await _productMetaRepository.InsertAsync(insertProductMeta);

                return new CreateProductMetaRs()
                {
                    ProductMeta = insertProductMeta.MapTo<ProductMetaDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductMetaRs> UpdateProductMeta(UpdateProductMetaRq rq)
        {
            try
            {
                ProductMeta updateProductMeta = rq.ProductMeta.MapTo<ProductMeta>();
                updateProductMeta = await _productMetaRepository.UpdateAsync(updateProductMeta);

                return new UpdateProductMetaRs()
                {
                    ProductMeta = updateProductMeta.MapTo<ProductMetaDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductMetaRs> DeleteProductMeta(DeleteProductMetaRq rq)
        {
            try
            {
                ProductMeta deleteProductMeta = rq.ProductMeta.MapTo<ProductMeta>();
                await _productMetaRepository.DeleteAsync(deleteProductMeta);

                return new DeleteProductMetaRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
