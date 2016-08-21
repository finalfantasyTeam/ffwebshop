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

        public ProductCategoryAppService(IProductCategoryRepository productManufatocryRepository)
        {
            _productCategoryRepository = productManufatocryRepository;
            Mapper.CreateMap<ProductCategory, ProductCategoryDTO>();
            Mapper.CreateMap<ProductCategoryDTO, ProductCategory>();
        }

        public async Task<ListProductCategoryRs> GetAllCategory()
        {
            try
            {
                List<ProductCategory> productCategories = await _productCategoryRepository.GetAllListAsync();
                return new ListProductCategoryRs()
                {
                    Categories = productCategories.MapTo<List<ProductCategoryDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductCategoryRs> GetCategoryById(GetProductCategoryRq rq)
        {
            ProductCategory productCategory = await _productCategoryRepository.GetAsync(rq.Id);

            return new GetProductCategoryRs()
            {
                Category = productCategory.MapTo<ProductCategoryDTO>()
            };
        }

        public async Task<GetProductCategoryRs> GetCategoryByName(GetProductCategoryRq rq)
        {
            ProductCategory productCategory = await _productCategoryRepository.GetCategoryByNameAsync(rq.Name);

            return new GetProductCategoryRs()
            {
                Category = productCategory.MapTo<ProductCategoryDTO>()
            };
        }

        public async Task<CreateProductCategoryRs> CreateCategory(CreateProductCategoryRq rq)
        {
            try
            {
                ProductCategory insertCategory = rq.Category.MapTo<ProductCategory>();
                insertCategory = await _productCategoryRepository.InsertAsync(insertCategory);

                return new CreateProductCategoryRs()
                {
                    Category = insertCategory.MapTo<ProductCategoryDTO>()
                };  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductCategoryRs> UpdateCategory(UpdateProductCategoryRq rq)
        {
            try
            {
                ProductCategory updateCategory = rq.Category.MapTo<ProductCategory>();
                updateCategory = await _productCategoryRepository.UpdateAsync(updateCategory);

                return new UpdateProductCategoryRs()
                {
                    Category = updateCategory.MapTo<ProductCategoryDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductCategoryRs> DeleteCategory(DeleteProductCategoryRq rq)
        {
            try
            {
                ProductCategory deleteCategory = rq.Category.MapTo<ProductCategory>();
                await _productCategoryRepository.DeleteAsync(deleteCategory);

                return new DeleteProductCategoryRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
