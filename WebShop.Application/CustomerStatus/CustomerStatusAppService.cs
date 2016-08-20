using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class CustomerStatusAppService : ICustomerStatusAppService
    {
        private readonly ICustomerStatusRepository _customerStatusRepository;

        public CustomerStatusAppService(ICustomerStatusRepository customerStatusRepository)
        {
            _customerStatusRepository = customerStatusRepository;
            Mapper.CreateMap<CustomerStatus, CustomerStatusDTO>();
            Mapper.CreateMap<CustomerStatusDTO, CustomerStatus>();
        }

        public async Task<ListCustomerStatusRs> GetAllCustomerStatus()
        {
            try
            {
                List<CustomerStatus> CustomerStatus = await _customerStatusRepository.GetAllListAsync();
                return new ListCustomerStatusRs()
                {
                    CustomerStatuses = CustomerStatus.MapTo<List<CustomerStatusDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerStatusRs> GetCustomerStatus(GetCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus customerStatus = await _customerStatusRepository.GetAsync(rq.Id);

                return new GetCustomerStatusRs()
                {
                    CustomerStatus = customerStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateCustomerStatusRs> CreateCustomerStatus(CreateCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus insertCustomerStatus = rq.CustomerStatus.MapTo<CustomerStatus>();
                insertCustomerStatus = await _customerStatusRepository.InsertAsync(insertCustomerStatus);

                return new CreateCustomerStatusRs()
                {
                    CustomerStatus = insertCustomerStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerStatusRs> UpdateCustomerStatus(UpdateCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus updateCustomerStatus = rq.CustomerStatus.MapTo<CustomerStatus>();
                updateCustomerStatus = await _customerStatusRepository.UpdateAsync(updateCustomerStatus);

                return new UpdateCustomerStatusRs()
                {
                    CustomerStatus = updateCustomerStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerStatusRs> DeleteCustomerStatus(DeleteCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus deleteCustomerStatus = rq.CustomerStatus.MapTo<CustomerStatus>();
                await _customerStatusRepository.DeleteAsync(deleteCustomerStatus);

                return new DeleteCustomerStatusRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
