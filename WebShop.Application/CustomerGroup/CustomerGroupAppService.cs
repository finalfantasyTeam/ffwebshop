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
    public class CustomerGroupAppService : ICustomerGroupAppService
    {
        private readonly ICustomerGroupRepository _CustomerGroupRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public CustomerGroupAppService(ICustomerGroupRepository CustomerGroupyRepository)
        {
            _CustomerGroupRepository = CustomerGroupyRepository;
            Mapper.CreateMap<CustomerGroupDTO, CustomerGroup>();
            Mapper.CreateMap<CustomerGroup, CustomerGroupDTO>();
        }

        public async Task<ListCustomerGroupRs> GetAllGroup()
        {
            try
            {
                List<CustomerGroup> CustomerGroupes = await _CustomerGroupRepository.GetAllListAsync();
                return new ListCustomerGroupRs()
                {
                    Groups = CustomerGroupes.MapTo<List<CustomerGroupDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerGroupRs> GetGroupById(GetCustomerGroupRq rq)
        {
            CustomerGroup CustomerGroup = await _CustomerGroupRepository.GetAsync(rq.Id);

            return new GetCustomerGroupRs()
            {
                Group = CustomerGroup.MapTo<CustomerGroupDTO>()
            };
        }

        public async Task<GetCustomerGroupRs> GetGroupByName(GetCustomerGroupRq rq)
        {
            CustomerGroup CustomerGroup = await _CustomerGroupRepository.GetGroupByNameAsync(rq.Name);

            return new GetCustomerGroupRs()
            {
                Group = CustomerGroup.MapTo<CustomerGroupDTO>()
            };
        }

        public async Task<CreateCustomerGroupRs> CreateGroup(CreateCustomerGroupRq rq)
        {
            try
            {
                rq.Group.CreateDate = DateTime.Now;
                CustomerGroup insertGroup = rq.Group.MapTo<CustomerGroup>();
                rq.Group.Id = await _CustomerGroupRepository.InsertAndGetIdAsync(insertGroup);

                return new CreateCustomerGroupRs()
                {
                    Group = rq.Group
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerGroupRs> UpdateGroup(UpdateCustomerGroupRq rq)
        {
            try
            {
                rq.Group.UpdateDate = DateTime.Now;
                CustomerGroup updateGroup = rq.Group.MapTo<CustomerGroup>();
                updateGroup = await _CustomerGroupRepository.UpdateAsync(updateGroup);

                return new UpdateCustomerGroupRs()
                {
                    Group = updateGroup.MapTo<CustomerGroupDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerGroupRs> DeleteGroup(DeleteCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup deleteGroup = rq.Group.MapTo<CustomerGroup>();
                await _CustomerGroupRepository.DeleteAsync(deleteGroup);

                return new DeleteCustomerGroupRs()
                {
                    Group = deleteGroup.MapTo<CustomerGroupDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
