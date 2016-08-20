using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customersRepository;

        public CustomerAppService(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }

        public async Task<ListCustomerRs> GetAllCustomer()
        {
            try
            {
                List<Customer> customers = await _customersRepository.GetAllListAsync();
                return new ListCustomerRs()
                {
                    Customers = customers.MapTo<List<CustomerDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerRs> GetCustomer(GetCustomerRq rq)
        {
            try
            {
                Customer customer = await _customersRepository.GetAsync(rq.Id);

                return new GetCustomerRs()
                {
                    Customer = customer.MapTo<CustomerDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateCustomerRs> CreateCustomer(CreateCustomerRq rq)
        {
            try
            {
                Customer insertCustomer = rq.Customer.MapTo<Customer>();
                insertCustomer = await _customersRepository.InsertAsync(insertCustomer);

                return new CreateCustomerRs()
                {
                    Customer = insertCustomer.MapTo<CustomerDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerRs> UpdateCustomer(UpdateCustomerRq rq)
        {
            try
            {
                Customer updateCustomer = rq.Customer.MapTo<Customer>();
                updateCustomer = await _customersRepository.UpdateAsync(updateCustomer);

                return new UpdateCustomerRs()
                {
                    Customer = updateCustomer.MapTo<CustomerDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerRs> DeleteCustomer(DeleteCustomerRq rq)
        {
            try
            {
                Customer deleteCustomer = rq.Customer.MapTo<Customer>();
                await _customersRepository.DeleteAsync(deleteCustomer);

                return new DeleteCustomerRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
