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
    public class CustomerOrderAppService : ICustomerOrderAppService
    {
        private readonly ICustomerOrderRepository _CustomerOrderRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public CustomerOrderAppService(ICustomerOrderRepository CustomerOrderRepository)
        {
            _CustomerOrderRepository = CustomerOrderRepository;
            Mapper.CreateMap<CustomerOrderDTO, CustomerOrder>();
            Mapper.CreateMap<CustomerOrder, CustomerOrderDTO>();
        }

        public async Task<ListCustomerOrderRs> GetAllOrder()
        {
            try
            {
                List<CustomerOrder> CustomerOrders = await _CustomerOrderRepository.GetAllListAsync();
                return new ListCustomerOrderRs()
                {
                    Orders = CustomerOrders.MapTo<List<CustomerOrderDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetCustomerOrderRs> GetOrderById(GetCustomerOrderRq rq)
        {
            CustomerOrder CustomerOrder = await _CustomerOrderRepository.GetAsync(rq.Id);

            return new GetCustomerOrderRs()
            {
                Order = CustomerOrder.MapTo<CustomerOrderDTO>()
            };
        }

        //public async Task<GetCustomerOrderRs> GetOrderByCustomerId(GetCustomerOrderRq rq)
        //{
        //    CustomerOrder CustomerOrder = await _CustomerOrderRepository.GetOrderByCustomerId(rq.CustomerId);

        //    return new GetCustomerOrderRs()
        //    {
        //        Order = CustomerOrder.MapTo<CustomerOrderDTO>()
        //    };
        //}

        public async Task<CreateCustomerOrderRs> CreateOrder(CreateCustomerOrderRq rq)
        {
            try
            {
                rq.Order.CreateDate = DateTime.Now;
                CustomerOrder insertOrder = rq.Order.MapTo<CustomerOrder>();
                rq.Order.Id = await _CustomerOrderRepository.InsertAndGetIdAsync(insertOrder);

                return new CreateCustomerOrderRs()
                {
                    Order = rq.Order
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateCustomerOrderRs> UpdateOrder(UpdateCustomerOrderRq rq)
        {
            try
            {
                rq.Order.CreateDate = DateTime.Now;
                CustomerOrder updateOrder = rq.Order.MapTo<CustomerOrder>();
                updateOrder = await _CustomerOrderRepository.UpdateAsync(updateOrder);

                return new UpdateCustomerOrderRs()
                {
                    Order = updateOrder.MapTo<CustomerOrderDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteCustomerOrderRs> DeleteOrder(DeleteCustomerOrderRq rq)
        {
            try
            {
                CustomerOrder deleteOrder = rq.Order.MapTo<CustomerOrder>();
                await _CustomerOrderRepository.DeleteAsync(deleteOrder);

                return new DeleteCustomerOrderRs()
                {
                    Order = deleteOrder.MapTo<CustomerOrderDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
