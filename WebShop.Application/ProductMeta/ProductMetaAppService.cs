using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Common;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductMetaAppService : IProductMetaAppService
    {
        private readonly IProductMetaRepository _productMetaRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public ProductMetaAppService(IProductMetaRepository productMetaRepository)
        {
            _productMetaRepository = productMetaRepository;
            Mapper.CreateMap<ProductMetaDTO, ProductMeta>();
            Mapper.CreateMap<ProductMeta, ProductMetaDTO>();
        }

        public async Task<ListProductMetaRs> GetAllMeta()
        {
            try
            {
                List<ProductMeta> productMetas = await _productMetaRepository.GetAllListAsync();
                return new ListProductMetaRs()
                {
                    Metas = productMetas.MapTo<List<ProductMetaDTO>>()
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

        public async Task<GetProductMetaRs> GetMetaByKey(GetProductMetaRq rq)
        {
            ProductMeta productMeta = await _productMetaRepository.GetMetaByKeyAsync(rq.Key);

            return new GetProductMetaRs()
            {
                Meta = productMeta.MapTo<ProductMetaDTO>()
            };
        }

        public async Task<CreateProductMetaRs> CreateMeta(CreateProductMetaRq rq)
        {
            try
            {
                ProductMeta insertMeta = rq.Meta.MapTo<ProductMeta>();
                rq.Meta.Id = await _productMetaRepository.InsertAndGetIdAsync(insertMeta);

                return new CreateProductMetaRs()
                {
                    Meta = rq.Meta
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
                ProductMeta updateMeta = rq.Meta.MapTo<ProductMeta>();
                updateMeta = await _productMetaRepository.UpdateAsync(updateMeta);

                return new UpdateProductMetaRs()
                {
                    Meta = updateMeta.MapTo<ProductMetaDTO>()
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
                ProductMeta deleteMeta = rq.Meta.MapTo<ProductMeta>();
                await _productMetaRepository.DeleteAsync(deleteMeta);

                return new DeleteProductMetaRs()
                {
                    Meta = deleteMeta.MapTo<ProductMetaDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
