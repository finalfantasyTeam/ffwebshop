using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Common;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productsRepository;

        public ProductAppService(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
            Mapper.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.FeatureImage, opt => opt
                .MapFrom(src => string.IsNullOrEmpty(src.FeatureImage) ? Constants.PLACEHOLDER_IMAGE_PATH : src.FeatureImage));
            Mapper.CreateMap<ProductDTO, Product>();

            Mapper.CreateMap<ProductCategory, ProductCategoryDTO>();
            Mapper.CreateMap<ProductBranch, ProductBranchDTO>();
            Mapper.CreateMap<ProductMeta, ProductMetaDTO>();
            Mapper.CreateMap<ProductStatus, ProductStatusDTO>();
            Mapper.CreateMap<ProductManufactory, ProductManufactoryDTO>();

        }

        public ListProductRs GetAllProducts()
        {
            try
            {
                IQueryable<Product> query = _productsRepository.GetAllIncluding(p => p.ProdCategory,
                                                                                    p => p.ProdBranch,
                                                                                    p => p.ProdStatus,
                                                                                    p => p.ProdManufactory,
                                                                                    p => p.ProductFields);

                List<Product> products = query.ToList();

                return new ListProductRs()
                {
                    Products = products.MapTo<List<ProductDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ListProductRs> GetAllProductsAsync()
        {
            try
            {
                List<Product> products = await _productsRepository.GetAllListAsync();

                return new ListProductRs()
                {
                    Products = products.MapTo<List<ProductDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductRs> GetProductById(GetProductRq rq)
        {
            try
            {
                Product product = await _productsRepository.GetAsync(rq.Id);

                return new GetProductRs()
                {
                    Product = product.MapTo<ProductDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateProductRs> CreateProduct(CreateProductRq rq)
        {
            try
            {
                Product insertProduct = rq.Product.MapTo<Product>();
                insertProduct = await _productsRepository.InsertAsync(insertProduct);

                return new CreateProductRs()
                {
                    Product = insertProduct.MapTo<ProductDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductRs> UpdateProduct(UpdateProductRq rq)
        {
            try
            {
                Product updateProduct = rq.Product.MapTo<Product>();
                updateProduct = await _productsRepository.UpdateAsync(updateProduct);

                return new UpdateProductRs()
                {
                    Product = updateProduct.MapTo<ProductDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductRs> DeleteProduct(DeleteProductRq rq)
        {
            try
            {
                Product deleteProduct = rq.Product.MapTo<Product>();
                await _productsRepository.DeleteAsync(deleteProduct);

                return new DeleteProductRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
