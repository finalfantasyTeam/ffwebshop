using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class OrderDetailAppService : IOrderDetailAppService
    {
        private readonly IOrderDetailRepository _orderDetailsRepository;

        public OrderDetailAppService(IOrderDetailRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
            Mapper.CreateMap<OrderDetail, OrderDetailDTO>();
            Mapper.CreateMap<OrderDetailDTO, OrderDetail>();
        }

        public async Task<ListOrderDetailRs> GetAllOrderDetails()
        {
            try
            {
                List<OrderDetail> orderDetails = await _orderDetailsRepository.GetAllListAsync();
                return new ListOrderDetailRs()
                {
                    OrderDetails = orderDetails.MapTo<List<OrderDetailDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetOrderDetailRs> GetOrderDetail(GetOrderDetailRq rq)
        {
            try
            {
                OrderDetail orderDetail = await _orderDetailsRepository.GetAsync(rq.Id);

                return new GetOrderDetailRs()
                {
                    OrderDetail = orderDetail.MapTo<OrderDetailDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateOrderDetailRs> CreateOrderDetail(CreateOrderDetailRq rq)
        {
            try
            {
                OrderDetail insertOrderDetail = rq.OrderDetail.MapTo<OrderDetail>();
                insertOrderDetail = await _orderDetailsRepository.InsertAsync(insertOrderDetail);

                return new CreateOrderDetailRs()
                {
                    OrderDetail = insertOrderDetail.MapTo<OrderDetailDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateOrderDetailRs> UpdateOrderDetail(UpdateOrderDetailRq rq)
        {
            try
            {
                OrderDetail updateOrderDetail = rq.OrderDetail.MapTo<OrderDetail>();
                updateOrderDetail = await _orderDetailsRepository.UpdateAsync(updateOrderDetail);

                return new UpdateOrderDetailRs()
                {
                    OrderDetail = updateOrderDetail.MapTo<OrderDetailDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteOrderDetailRs> DeleteOrderDetail(DeleteOrderDetailRq rq)
        {
            try
            {
                OrderDetail deleteOrderDetail = rq.OrderDetail.MapTo<OrderDetail>();
                await _orderDetailsRepository.DeleteAsync(deleteOrderDetail);

                return new DeleteOrderDetailRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
