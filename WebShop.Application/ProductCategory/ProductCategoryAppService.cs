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
    public class ProductCategoryAppService : IProductCategoryAppService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryAppService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            Mapper.CreateMap<ProductCategory, ProductCategoryDTO>()
                .ForMember(dest => dest.ImageToShow, opt => opt
                .MapFrom(src => string.IsNullOrEmpty(src.ImageToShow) ? Constants.PLACEHOLDER_IMAGE_PATH : src.ImageToShow));

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
                rq.Category.CreateDate = DateTime.Now;
                ProductCategory insertCategory = rq.Category.MapTo<ProductCategory>();
                rq.Category.Id = await _productCategoryRepository.InsertAndGetIdAsync(insertCategory);

                return new CreateProductCategoryRs()
                {
                    Category = rq.Category
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
                rq.Category.UpdateDate = DateTime.Now;
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

                // if co product 
                ProductCategory child = _productCategoryRepository.FirstOrDefault(c => c.ParentCat == deleteCategory.Id);
                if(child != null)
                {
                    return new DeleteProductCategoryRs()
                    {
                        Category = null
                    };
                }
                else
                {
                    await _productCategoryRepository.DeleteAsync(deleteCategory);

                    return new DeleteProductCategoryRs()
                    {
                        Category = deleteCategory.MapTo<ProductCategoryDTO>()
                    };
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
