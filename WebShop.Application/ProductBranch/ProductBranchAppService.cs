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
    public class ProductBranchAppService : IProductBranchAppService
    {
        private readonly IProductBranchRepository _productBranchRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public ProductBranchAppService(IProductBranchRepository productBranchyRepository)
        {
            _productBranchRepository = productBranchyRepository;
            Mapper.CreateMap<ProductBranch, ProductBranchDTO>()
                .ForMember(dest => dest.BranchLogo, opt => opt
                .MapFrom(src => string.IsNullOrEmpty(src.BranchLogo) ? Constants.PLACEHOLDER_IMAGE_PATH : src.BranchLogo));

            Mapper.CreateMap<ProductBranchDTO, ProductBranch>();
        }

        public async Task<ListProductBranchRs> GetAllBranch()
        {
            try
            {
                List<ProductBranch> productBranches = await _productBranchRepository.GetAllListAsync();
                return new ListProductBranchRs()
                {
                    Branches = productBranches.MapTo<List<ProductBranchDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProductBranchRs> GetBranchById(GetProductBranchRq rq)
        {
            ProductBranch productBranch = await _productBranchRepository.GetAsync(rq.Id);

            return new GetProductBranchRs()
            {
                Branch = productBranch.MapTo<ProductBranchDTO>()
            };
        }

        public async Task<GetProductBranchRs> GetBranchByName(GetProductBranchRq rq)
        {
            ProductBranch productBranch = await _productBranchRepository.GetBranchByNameAsync(rq.Name);

            return new GetProductBranchRs()
            {
                Branch = productBranch.MapTo<ProductBranchDTO>()
            };
        }

        public async Task<CreateProductBranchRs> CreateBranch(CreateProductBranchRq rq)
        {
            try
            {
                rq.Branch.CreateDate = DateTime.Now;
                ProductBranch insertBranch = rq.Branch.MapTo<ProductBranch>();
                rq.Branch.Id = await _productBranchRepository.InsertAndGetIdAsync(insertBranch);

                return new CreateProductBranchRs()
                {
                    Branch = rq.Branch
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
                rq.Branch.UpdateDate = DateTime.Now;
                ProductBranch updateBranch = rq.Branch.MapTo<ProductBranch>();
                updateBranch = await _productBranchRepository.UpdateAsync(updateBranch);

                return new UpdateProductBranchRs()
                {
                    Branch = updateBranch.MapTo<ProductBranchDTO>()
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
                ProductBranch deleteBranch = rq.Branch.MapTo<ProductBranch>();
                await _productBranchRepository.DeleteAsync(deleteBranch);

                return new DeleteProductBranchRs()
                {
                    Branch = deleteBranch.MapTo<ProductBranchDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
