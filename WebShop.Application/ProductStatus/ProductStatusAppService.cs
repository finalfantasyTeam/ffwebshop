using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductStatusAppService : IProductStatusAppService
    {
        private readonly IProductStatusRepository _productStatusRepository;

        public ProductStatusAppService(IProductStatusRepository productStatusRepository)
        {
            _productStatusRepository = productStatusRepository;
            Mapper.CreateMap<ProductStatus, ProductStatusDTO>();
            Mapper.CreateMap<ProductStatusDTO, ProductStatus>();
        }

        public async Task<ListProductStatusRs> GetAllProductStatus()
        {
            try
            {
                List<ProductStatus> productStatus = await _productStatusRepository.GetAllListAsync();
                return new ListProductStatusRs()
                {
                    ProductStatus = productStatus.MapTo<List<ProductStatusDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductStatusRs> GetProductStatus(GetProductStatusRq rq)
        {
            ProductStatus ProductStatus = await _productStatusRepository.GetAsync(rq.Id);

            return new GetProductStatusRs()
            {
                ProductStatus = ProductStatus.MapTo<ProductStatusDTO>()
            };
        }

        public async Task<CreateProductStatusRs> CreateProductStatus(CreateProductStatusRq rq)
        {
            try
            {
                ProductStatus insertProductStatus = rq.ProductStatus.MapTo<ProductStatus>();
                insertProductStatus = await _productStatusRepository.InsertAsync(insertProductStatus);

                return new CreateProductStatusRs()
                {
                    ProductStatus = insertProductStatus.MapTo<ProductStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductStatusRs> UpdateProductStatus(UpdateProductStatusRq rq)
        {
            try
            {
                ProductStatus updateProductStatus = rq.ProductStatus.MapTo<ProductStatus>();
                updateProductStatus = await _productStatusRepository.UpdateAsync(updateProductStatus);

                return new UpdateProductStatusRs()
                {
                    ProductStatus = updateProductStatus.MapTo<ProductStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductStatusRs> DeleteProductStatus(DeleteProductStatusRq rq)
        {
            try
            {
                ProductStatus deleteProductStatus = rq.ProductStatus.MapTo<ProductStatus>();
                await _productStatusRepository.DeleteAsync(deleteProductStatus);

                return new DeleteProductStatusRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
