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

        public async Task<ListCustomerStatusRs> GetAllStatus()
        {
            try
            {
                List<CustomerStatus> CustomerStatus = await _customerStatusRepository.GetAllListAsync();
                return new ListCustomerStatusRs()
                {
                    Statuses = CustomerStatus.MapTo<List<CustomerStatusDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerStatusRs> GetStatusById(GetCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus customerStatus = await _customerStatusRepository.GetAsync(rq.Id);

                return new GetCustomerStatusRs()
                {
                    Status = customerStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateCustomerStatusRs> CreateStatus(CreateCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus insertCustomerStatus = rq.Status.MapTo<CustomerStatus>();
                insertCustomerStatus = await _customerStatusRepository.InsertAsync(insertCustomerStatus);

                return new CreateCustomerStatusRs()
                {
                    Status = insertCustomerStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerStatusRs> UpdateStatus(UpdateCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus updateCustomerStatus = rq.Status.MapTo<CustomerStatus>();
                updateCustomerStatus = await _customerStatusRepository.UpdateAsync(updateCustomerStatus);

                return new UpdateCustomerStatusRs()
                {
                    Status = updateCustomerStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerStatusRs> DeleteStatus(DeleteCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus deleteCustomerStatus = rq.Status.MapTo<CustomerStatus>();
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
