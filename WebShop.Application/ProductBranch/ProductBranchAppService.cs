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

        public async Task<ListProductBranchRs> GetAllBranch()
        {
            try
            {
                List<ProductBranch> ProductBranch = await _productBranchRepository.GetAllListAsync();
                return new ListProductBranchRs()
                {
                    Branches = ProductBranch.MapTo<List<ProductBranchDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductBranchRs> GetBranchById(GetProductBranchRq rq)
        {
            ProductBranch ProductBranch = await _productBranchRepository.GetAsync(rq.Id);

            return new GetProductBranchRs()
            {
                Branch = ProductBranch.MapTo<ProductBranchDTO>()
            };
        }

        public async Task<CreateProductBranchRs> CreateBranch(CreateProductBranchRq rq)
        {
            try
            {
                ProductBranch insertProductBranch = rq.Branch.MapTo<ProductBranch>();
                insertProductBranch = await _productBranchRepository.InsertAsync(insertProductBranch);

                return new CreateProductBranchRs()
                {
                    Branch = insertProductBranch.MapTo<ProductBranchDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateProductBranchRs> UpdateBranch(UpdateProductBranchRq rq)
        {
            try
            {
                ProductBranch updateProductBranch = rq.Branch.MapTo<ProductBranch>();
                updateProductBranch = await _productBranchRepository.UpdateAsync(updateProductBranch);

                return new UpdateProductBranchRs()
                {
                    Branch = updateProductBranch.MapTo<ProductBranchDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteProductBranchRs> DeleteBranch(DeleteProductBranchRq rq)
        {
            try
            {
                ProductBranch deleteProductBranch = rq.Branch.MapTo<ProductBranch>();
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
