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

        public async Task<ListProductMetaRs> GetAllMeta()
        {
            try
            {
                List<ProductMeta> productMeta = await _productMetaRepository.GetAllListAsync();
                return new ListProductMetaRs()
                {
                    Metas = productMeta.MapTo<List<ProductMetaDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductMetaRs> GetMetaById(GetProductMetaRq rq)
        {
            ProductMeta productMeta = await _productMetaRepository.GetAsync(rq.Id);

            return new GetProductMetaRs()
            {
                Meta = productMeta.MapTo<ProductMetaDTO>()
            };
        }

        public async Task<CreateProductMetaRs> CreateMeta(CreateProductMetaRq rq)
        {
            try
            {
                ProductMeta insertProductMeta = rq.Meta.MapTo<ProductMeta>();
                insertProductMeta = await _productMetaRepository.InsertAsync(insertProductMeta);

                return new CreateProductMetaRs()
                {
                    Meta = insertProductMeta.MapTo<ProductMetaDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductMetaRs> UpdateMeta(UpdateProductMetaRq rq)
        {
            try
            {
                ProductMeta updateProductMeta = rq.Meta.MapTo<ProductMeta>();
                updateProductMeta = await _productMetaRepository.UpdateAsync(updateProductMeta);

                return new UpdateProductMetaRs()
                {
                    Meta = updateProductMeta.MapTo<ProductMetaDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductMetaRs> DeleteMeta(DeleteProductMetaRq rq)
        {
            try
            {
                ProductMeta deleteProductMeta = rq.Meta.MapTo<ProductMeta>();
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
