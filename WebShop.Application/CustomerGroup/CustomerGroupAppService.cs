using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class CustomerGroupAppService : ICustomerGroupAppService
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupAppService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
            Mapper.CreateMap<CustomerGroup, CustomerGroupDTO>();
            Mapper.CreateMap<CustomerGroupDTO, CustomerGroup>();
        }

        public async Task<ListCustomerGroupRs> GetAllGroup()
        {
            try
            {
                List<CustomerGroup> CustomerGroup = await _customerGroupRepository.GetAllListAsync();
                return new ListCustomerGroupRs()
                {
                    Groups = CustomerGroup.MapTo<List<CustomerGroupDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerGroupRs> GetGroupById(GetCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup customerGroup = await _customerGroupRepository.GetAsync(rq.Id);

                return new GetCustomerGroupRs()
                {
                    Group = customerGroup.MapTo<CustomerGroupDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateCustomerGroupRs> CreateGroup(CreateCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup insertCustomerGroup = rq.Group.MapTo<CustomerGroup>();
                insertCustomerGroup = await _customerGroupRepository.InsertAsync(insertCustomerGroup);

                return new CreateCustomerGroupRs()
                {
                    Group = insertCustomerGroup.MapTo<CustomerGroupDTO>()
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
                CustomerGroup updateCustomerGroup = rq.Group.MapTo<CustomerGroup>();
                updateCustomerGroup = await _customerGroupRepository.UpdateAsync(updateCustomerGroup);

                return new UpdateCustomerGroupRs()
                {
                    Group = updateCustomerGroup.MapTo<CustomerGroupDTO>()
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
                CustomerGroup deleteCustomerGroup = rq.Group.MapTo<CustomerGroup>();
                await _customerGroupRepository.DeleteAsync(deleteCustomerGroup);

                return new DeleteCustomerGroupRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
