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
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _ProductRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public ProductAppService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
            Mapper.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.FeatureImage, opt => opt
                .MapFrom(src => string.IsNullOrEmpty(src.FeatureImage) ? Constants.PLACEHOLDER_IMAGE_PATH : src.FeatureImage));
                
            Mapper.CreateMap<ProductDTO, Product>();
            Mapper.CreateMap<Product, ProductDTO>();
        }

        public async Task<ListProductRs> GetAllProducts()
        {
            try
            {
                List<Product> productProducts = await _ProductRepository.GetAllListAsync();
                return new ListProductRs()
                {
                    Products = productProducts.MapTo<List<ProductDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductRs> GetProductById(GetProductRq rq)
        {
            Product Product = await _ProductRepository.GetAsync(rq.Id);

            return new GetProductRs()
            {
                Product = Product.MapTo<ProductDTO>()
            };
        }

        public async Task<GetProductRs> GetProductByName(GetProductRq rq)
        {
            Product Product = await _ProductRepository.GetProductByNameAsync(rq.Name);

            return new GetProductRs()
            {
                Product = Product.MapTo<ProductDTO>()
            };
        }

        public async Task<CreateProductRs> CreateProduct(CreateProductRq rq)
        {
            try
            {
                rq.Product.CreateDate = DateTime.Now;
                Product insertProduct = rq.Product.MapTo<Product>();
                rq.Product.Id = await _ProductRepository.InsertAndGetIdAsync(insertProduct);

                return new CreateProductRs()
                {
                    Product = rq.Product
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
                rq.Product.UpdateDate = DateTime.Now;
                Product updateProduct = rq.Product.MapTo<Product>();
                updateProduct = await _ProductRepository.UpdateAsync(updateProduct);

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
                await _ProductRepository.DeleteAsync(deleteProduct);

                return new DeleteProductRs()
                {
                    Product = deleteProduct.MapTo<ProductDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
