using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductManufactoryAppService : IProductManufactoryAppService
    {
        private readonly IProductManufactoryRepository _productManufactoryRepository;

        public ProductManufactoryAppService(IProductManufactoryRepository productManufatocryRepository)
        {
            _productManufactoryRepository = productManufatocryRepository;
            Mapper.CreateMap<ProductManufactory, ProductManufactoryDTO>();
            Mapper.CreateMap<ProductManufactoryDTO, ProductManufactory>();
        }

        public async Task<ListProductManufactoryRs> GetAllManufactory()
        {
            try
            {
                List<ProductManufactory> productManufactories = await _productManufactoryRepository.GetAllListAsync();
                return new ListProductManufactoryRs()
                {
                    Manufactories = productManufactories.MapTo<List<ProductManufactoryDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductManufactoryRs> GetManufactoryById(GetProductManufactoryRq rq)
        {
            ProductManufactory productManufactory = await _productManufactoryRepository.GetAsync(rq.Id);

            return new GetProductManufactoryRs()
            {
                Manufactory = productManufactory.MapTo<ProductManufactoryDTO>()
            };
        }

        public async Task<GetProductManufactoryRs> GetManufactoryByName(GetProductManufactoryRq rq)
        {
            ProductManufactory productManufactory = await _productManufactoryRepository.GetManufactoryByNameAsync(rq.Name);

            return new GetProductManufactoryRs()
            {
                Manufactory = productManufactory.MapTo<ProductManufactoryDTO>()
            };
        }

        public async Task<CreateProductManufactoryRs> CreateManufactory(CreateProductManufactoryRq rq)
        {
            try
            {
                rq.Manufactory.CreateDate = DateTime.Now;
                ProductManufactory insertManufactory = rq.Manufactory.MapTo<ProductManufactory>();
                rq.Manufactory.Id = await _productManufactoryRepository.InsertAndGetIdAsync(insertManufactory);

                return new CreateProductManufactoryRs()
                {
                    Manufactory = rq.Manufactory
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductManufactoryRs> UpdateManufactory(UpdateProductManufactoryRq rq)
        {
            try
            {
                rq.Manufactory.UpdateDate = DateTime.Now;
                ProductManufactory updateManufactory = rq.Manufactory.MapTo<ProductManufactory>();
                updateManufactory = await _productManufactoryRepository.UpdateAsync(updateManufactory);

                return new UpdateProductManufactoryRs()
                {
                    Manufactory = updateManufactory.MapTo<ProductManufactoryDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductManufactoryRs> DeleteManufactory(DeleteProductManufactoryRq rq)
        {
            try
            {
                ProductManufactory deleteManufactory = rq.Manufactory.MapTo<ProductManufactory>();
                await _productManufactoryRepository.DeleteAsync(deleteManufactory);

                return new DeleteProductManufactoryRs()
                {
                    Manufactory = deleteManufactory.MapTo<ProductManufactoryDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
