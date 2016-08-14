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
        private readonly IProductManufactoryRepository _productManufatocryRepository;

        public ProductManufactoryAppService(IProductManufactoryRepository productManufatocryRepository)
        {
            _productManufatocryRepository = productManufatocryRepository;
            Mapper.CreateMap<ProductManufactory, ProductManufactoryDTO>();
            Mapper.CreateMap<ProductManufactoryDTO, ProductManufactory>();
        }

        public async Task<ListProductManufactoryRs> GetAllManufactory()
        {
            try
            {
                List<ProductManufactory> productManufactories = await _productManufatocryRepository.GetAllListAsync();
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
            ProductManufactory productManufactory = await _productManufatocryRepository.GetAsync(rq.Id);

            return new GetProductManufactoryRs()
            {
                Manufactory = productManufactory.MapTo<ProductManufactoryDTO>()
            };
        }

        public async Task<GetProductManufactoryRs> GetManufactoryByName(GetProductManufactoryRq rq)
        {
            ProductManufactory productManufactory = await _productManufatocryRepository.GetManufactoryByNameAsync(rq.Name);

            return new GetProductManufactoryRs()
            {
                Manufactory = productManufactory.MapTo<ProductManufactoryDTO>()
            };
        }

        public async Task<CreateProductManufactoryRs> CreateManufactory(CreateProductManufactoryRq rq)
        {
            try
            {
                ProductManufactory insertManufacotry = rq.Manufactory.MapTo<ProductManufactory>();
                insertManufacotry = await _productManufatocryRepository.InsertAsync(insertManufacotry);

                return new CreateProductManufactoryRs()
                {
                    Manufactory = insertManufacotry.MapTo<ProductManufactoryDTO>()
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
                ProductManufactory updateManufacotry = rq.Manufactory.MapTo<ProductManufactory>();
                updateManufacotry = await _productManufatocryRepository.UpdateAsync(updateManufacotry);

                return new UpdateProductManufactoryRs()
                {
                    Manufactory = updateManufacotry.MapTo<ProductManufactoryDTO>()
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
                ProductManufactory deleteManufacotry = rq.Manufactory.MapTo<ProductManufactory>();
                await _productManufatocryRepository.DeleteAsync(deleteManufacotry);

                return new DeleteProductManufactoryRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
