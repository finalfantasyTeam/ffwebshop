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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _CustomerRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public CustomerAppService(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Customer, CustomerDTO>();
        }

        public async Task<ListCustomerRs> GetAllCustomer()
        {
            try
            {
                List<Customer> Customers = await _CustomerRepository.GetAllListAsync();
                return new ListCustomerRs()
                {
                    Customers = Customers.MapTo<List<CustomerDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerRs> GetCustomerById(GetCustomerRq rq)
        {
            Customer Customer = await _CustomerRepository.GetAsync(rq.Id);

            return new GetCustomerRs()
            {
                Customer = Customer.MapTo<CustomerDTO>()
            };
        }

        public async Task<GetCustomerRs> GetCustomerByFirstName(GetCustomerRq rq)
        {
            Customer Customer = await _CustomerRepository.GetCustomerByFirstNameAsync(rq.FirstName);

            return new GetCustomerRs()
            {
                Customer = Customer.MapTo<CustomerDTO>()
            };
        }

        public async Task<CreateCustomerRs> CreateCustomer(CreateCustomerRq rq)
        {
            try
            {
                rq.Customer.JoinDate = DateTime.Now;
                Customer insertCustomer = rq.Customer.MapTo<Customer>();
                rq.Customer.Id = await _CustomerRepository.InsertAndGetIdAsync(insertCustomer);

                return new CreateCustomerRs()
                {
                    Customer = rq.Customer
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
                rq.Customer.JoinDate = DateTime.Now;
                Customer updateCustomer = rq.Customer.MapTo<Customer>();
                updateCustomer = await _CustomerRepository.UpdateAsync(updateCustomer);

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
                await _CustomerRepository.DeleteAsync(deleteCustomer);

                return new DeleteCustomerRs()
                {
                    Customer = deleteCustomer.MapTo<CustomerDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
