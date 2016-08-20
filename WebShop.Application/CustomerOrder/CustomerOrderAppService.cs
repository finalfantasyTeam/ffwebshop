using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class CustomerOrderAppService : ICustomerOrderAppService
    {
        private readonly ICustomerOrderRepository _customerOrdersRepository;

        public CustomerOrderAppService(ICustomerOrderRepository customerOrdersRepository)
        {
            _customerOrdersRepository = customerOrdersRepository;
            Mapper.CreateMap<CustomerOrder, CustomerOrderDTO>();
            Mapper.CreateMap<CustomerOrderDTO, CustomerOrder>();
        }

        public async Task<ListCustomerOrderRs> GetAllCustomerOrder()
        {
            try
            {
                List<CustomerOrder> customerOrders = await _customerOrdersRepository.GetAllListAsync();
                return new ListCustomerOrderRs()
                {
                    CustomerOrders = customerOrders.MapTo<List<CustomerOrderDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerOrderRs> GetCustomerOrder(GetCustomerOrderRq rq)
        {
            try
            {
                CustomerOrder customerOrder = await _customerOrdersRepository.GetAsync(rq.Id);

                return new GetCustomerOrderRs()
                {
                    CustomerOrder = customerOrder.MapTo<CustomerOrderDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateCustomerOrderRs> CreateCustomerOrder(CreateCustomerOrderRq rq)
        {
            try
            {
                CustomerOrder insertCustomerOrder = rq.CustomerOrder.MapTo<CustomerOrder>();
                insertCustomerOrder = await _customerOrdersRepository.InsertAsync(insertCustomerOrder);

                return new CreateCustomerOrderRs()
                {
                    CustomerOrder = insertCustomerOrder.MapTo<CustomerOrderDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerOrderRs> UpdateCustomerOrder(UpdateCustomerOrderRq rq)
        {
            try
            {
                CustomerOrder updateCustomerOrder = rq.CustomerOrder.MapTo<CustomerOrder>();
                updateCustomerOrder = await _customerOrdersRepository.UpdateAsync(updateCustomerOrder);

                return new UpdateCustomerOrderRs()
                {
                    CustomerOrder = updateCustomerOrder.MapTo<CustomerOrderDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerOrderRs> DeleteCustomerOrder(DeleteCustomerOrderRq rq)
        {
            try
            {
                CustomerOrder deleteCustomerOrder = rq.CustomerOrder.MapTo<CustomerOrder>();
                await _customerOrdersRepository.DeleteAsync(deleteCustomerOrder);

                return new DeleteCustomerOrderRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
