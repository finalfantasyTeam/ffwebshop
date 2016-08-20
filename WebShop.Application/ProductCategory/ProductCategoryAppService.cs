using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductCategoryAppService : IProductCategoryAppService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryAppService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            Mapper.CreateMap<ProductCategory, ProductCategoryDTO>();
            Mapper.CreateMap<ProductCategoryDTO, ProductCategory>();
        }

        public async Task<ListProductCategoryRs> GetAllProductCategory()
        {
            try
            {
                List<ProductCategory> productCategory = await _productCategoryRepository.GetAllListAsync();
                return new ListProductCategoryRs()
                {
                    ProductCategories = productCategory.MapTo<List<ProductCategoryDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductCategoryRs> GetProductCategory(GetProductCategoryRq rq)
        {
            ProductCategory productCategory = await _productCategoryRepository.GetAsync(rq.Id);

            return new GetProductCategoryRs()
            {
                ProductCategory = productCategory.MapTo<ProductCategoryDTO>()
            };
        }

        public async Task<CreateProductCategoryRs> CreateProductCategory(CreateProductCategoryRq rq)
        {
            try
            {
                ProductCategory insertProductCategory = rq.ProductCategory.MapTo<ProductCategory>();
                insertProductCategory = await _productCategoryRepository.InsertAsync(insertProductCategory);

                return new CreateProductCategoryRs()
                {
                    ProductCategory = insertProductCategory.MapTo<ProductCategoryDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductCategoryRs> UpdateProductCategory(UpdateProductCategoryRq rq)
        {
            try
            {
                ProductCategory updateProductCategory = rq.ProductCategory.MapTo<ProductCategory>();
                updateProductCategory = await _productCategoryRepository.UpdateAsync(updateProductCategory);

                return new UpdateProductCategoryRs()
                {
                    ProductCategory = updateProductCategory.MapTo<ProductCategoryDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductCategoryRs> DeleteProductCategory(DeleteProductCategoryRq rq)
        {
            try
            {
                ProductCategory deleteProductCategory = rq.ProductCategory.MapTo<ProductCategory>();
                await _productCategoryRepository.DeleteAsync(deleteProductCategory);

                return new DeleteProductCategoryRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
