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
    public class ProductStatusAppService : IProductStatusAppService
    {
        private readonly IProductStatusRepository _productStatusRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public ProductStatusAppService(IProductStatusRepository productStatusRepository)
        {
            _productStatusRepository = productStatusRepository;
            Mapper.CreateMap<ProductStatusDTO, ProductStatus>();
            Mapper.CreateMap<ProductStatus, ProductStatusDTO>();
        }

        public async Task<ListProductStatusRs> GetAllStatus()
        {
            try
            {
                List<ProductStatus> productStatuses = await _productStatusRepository.GetAllListAsync();
                return new ListProductStatusRs()
                {
                    Statuses = productStatuses.MapTo<List<ProductStatusDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductStatusRs> GetStatusById(GetProductStatusRq rq)
        {
            ProductStatus productStatus = await _productStatusRepository.GetAsync(rq.Id);

            return new GetProductStatusRs()
            {
                Status = productStatus.MapTo<ProductStatusDTO>()
            };
        }

        public async Task<GetProductStatusRs> GetStatusByName(GetProductStatusRq rq)
        {
            ProductStatus productStatus = await _productStatusRepository.GetStatusByNameAsync(rq.Name);

            return new GetProductStatusRs()
            {
                Status = productStatus.MapTo<ProductStatusDTO>()
            };
        }

        public async Task<CreateProductStatusRs> CreateStatus(CreateProductStatusRq rq)
        {
            try
            {
                ProductStatus insertStatus = rq.Status.MapTo<ProductStatus>();
                rq.Status.Id = await _productStatusRepository.InsertAndGetIdAsync(insertStatus);

                return new CreateProductStatusRs()
                {
                    Status = rq.Status
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductStatusRs> UpdateStatus(UpdateProductStatusRq rq)
        {
            try
            {
                ProductStatus updateStatus = rq.Status.MapTo<ProductStatus>();
                updateStatus = await _productStatusRepository.UpdateAsync(updateStatus);

                return new UpdateProductStatusRs()
                {
                    Status = updateStatus.MapTo<ProductStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductStatusRs> DeleteStatus(DeleteProductStatusRq rq)
        {
            try
            {
                ProductStatus deleteStatus = rq.Status.MapTo<ProductStatus>();
                await _productStatusRepository.DeleteAsync(deleteStatus);

                return new DeleteProductStatusRs()
                {
                    Status = deleteStatus.MapTo<ProductStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
