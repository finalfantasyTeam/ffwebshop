using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class ProductBranchAppService : IProductBranchAppService
    {
        private readonly IProductBranchRepository _productBranchRepository;

        public ProductBranchAppService(IProductBranchRepository productBranchRepository)
        {
            _productBranchRepository = productBranchRepository;
            Mapper.CreateMap<ProductBranch, ProductBranchDTO>();
            Mapper.CreateMap<ProductBranchDTO, ProductBranch>();
        }

        public async Task<ListProductBranchRs> GetAllProductBranch()
        {
            try
            {
                List<ProductBranch> ProductBranch = await _productBranchRepository.GetAllListAsync();
                return new ListProductBranchRs()
                {
                    ProductBranches = ProductBranch.MapTo<List<ProductBranchDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductBranchRs> GetProductBranch(GetProductBranchRq rq)
        {
            ProductBranch ProductBranch = await _productBranchRepository.GetAsync(rq.Id);

            return new GetProductBranchRs()
            {
                ProductBranch = ProductBranch.MapTo<ProductBranchDTO>()
            };
        }

        public async Task<CreateProductBranchRs> CreateProductBranch(CreateProductBranchRq rq)
        {
            try
            {
                ProductBranch insertProductBranch = rq.ProductBranch.MapTo<ProductBranch>();
                insertProductBranch = await _productBranchRepository.InsertAsync(insertProductBranch);

                return new CreateProductBranchRs()
                {
                    ProductBranch = insertProductBranch.MapTo<ProductBranchDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductBranchRs> UpdateProductBranch(UpdateProductBranchRq rq)
        {
            try
            {
                ProductBranch updateProductBranch = rq.ProductBranch.MapTo<ProductBranch>();
                updateProductBranch = await _productBranchRepository.UpdateAsync(updateProductBranch);

                return new UpdateProductBranchRs()
                {
                    ProductBranch = updateProductBranch.MapTo<ProductBranchDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductBranchRs> DeleteProductBranch(DeleteProductBranchRq rq)
        {
            try
            {
                ProductBranch deleteProductBranch = rq.ProductBranch.MapTo<ProductBranch>();
                await _productBranchRepository.DeleteAsync(deleteProductBranch);

                return new DeleteProductBranchRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
