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
    public class CustomerStatusAppService : ICustomerStatusAppService
    {
        private readonly ICustomerStatusRepository _CustomerStatusRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public CustomerStatusAppService(ICustomerStatusRepository CustomerStatusRepository)
        {
            _CustomerStatusRepository = CustomerStatusRepository;
            Mapper.CreateMap<CustomerStatusDTO, CustomerStatus>();
            Mapper.CreateMap<CustomerStatus, CustomerStatusDTO>();
        }

        public async Task<ListCustomerStatusRs> GetAllStatus()
        {
            try
            {
                List<CustomerStatus> CustomerStatuses = await _CustomerStatusRepository.GetAllListAsync();
                return new ListCustomerStatusRs()
                {
                    Statuses = CustomerStatuses.MapTo<List<CustomerStatusDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerStatusRs> GetStatusById(GetCustomerStatusRq rq)
        {
            CustomerStatus CustomerStatus = await _CustomerStatusRepository.GetAsync(rq.Id);

            return new GetCustomerStatusRs()
            {
                Status = CustomerStatus.MapTo<CustomerStatusDTO>()
            };
        }

        public async Task<GetCustomerStatusRs> GetStatusByName(GetCustomerStatusRq rq)
        {
            CustomerStatus CustomerStatus = await _CustomerStatusRepository.GetStatusByNameAsync(rq.Name);

            return new GetCustomerStatusRs()
            {
                Status = CustomerStatus.MapTo<CustomerStatusDTO>()
            };
        }

        public async Task<CreateCustomerStatusRs> CreateStatus(CreateCustomerStatusRq rq)
        {
            try
            {
                CustomerStatus insertStatus = rq.Status.MapTo<CustomerStatus>();
                rq.Status.Id = await _CustomerStatusRepository.InsertAndGetIdAsync(insertStatus);

                return new CreateCustomerStatusRs()
                {
                    Status = rq.Status
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
                CustomerStatus updateStatus = rq.Status.MapTo<CustomerStatus>();
                updateStatus = await _CustomerStatusRepository.UpdateAsync(updateStatus);

                return new UpdateCustomerStatusRs()
                {
                    Status = updateStatus.MapTo<CustomerStatusDTO>()
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
                CustomerStatus deleteStatus = rq.Status.MapTo<CustomerStatus>();
                await _CustomerStatusRepository.DeleteAsync(deleteStatus);

                return new DeleteCustomerStatusRs()
                {
                    Status = deleteStatus.MapTo<CustomerStatusDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
