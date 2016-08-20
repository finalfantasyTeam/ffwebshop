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

        public async Task<ListCustomerGroupRs> GetAllCustomerGroup()
        {
            try
            {
                List<CustomerGroup> CustomerGroup = await _customerGroupRepository.GetAllListAsync();
                return new ListCustomerGroupRs()
                {
                    CustomerGroups = CustomerGroup.MapTo<List<CustomerGroupDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerGroupRs> GetCustomerGroup(GetCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup customerGroup = await _customerGroupRepository.GetAsync(rq.Id);

                return new GetCustomerGroupRs()
                {
                    CustomerGroup = customerGroup.MapTo<CustomerGroupDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateCustomerGroupRs> CreateCustomerGroup(CreateCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup insertCustomerGroup = rq.CustomerGroup.MapTo<CustomerGroup>();
                insertCustomerGroup = await _customerGroupRepository.InsertAsync(insertCustomerGroup);

                return new CreateCustomerGroupRs()
                {
                    CustomerGroup = insertCustomerGroup.MapTo<CustomerGroupDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerGroupRs> UpdateCustomerGroup(UpdateCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup updateCustomerGroup = rq.CustomerGroup.MapTo<CustomerGroup>();
                updateCustomerGroup = await _customerGroupRepository.UpdateAsync(updateCustomerGroup);

                return new UpdateCustomerGroupRs()
                {
                    CustomerGroup = updateCustomerGroup.MapTo<CustomerGroupDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerGroupRs> DeleteCustomerGroup(DeleteCustomerGroupRq rq)
        {
            try
            {
                CustomerGroup deleteCustomerGroup = rq.CustomerGroup.MapTo<CustomerGroup>();
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
