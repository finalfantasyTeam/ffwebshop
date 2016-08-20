using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class InvoiceDetailAppService : IInvoiceDetailAppService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailsRepository;

        public InvoiceDetailAppService(IInvoiceDetailRepository invoiceDetailsRepository)
        {
            _invoiceDetailsRepository = invoiceDetailsRepository;
            Mapper.CreateMap<InvoiceDetail, InvoiceDetailDTO>();
            Mapper.CreateMap<InvoiceDetailDTO, InvoiceDetail>();
        }

        public async Task<ListInvoiceDetailRs> GetAllInvoiceDetails()
        {
            try
            {
                List<InvoiceDetail> invoiceDetails = await _invoiceDetailsRepository.GetAllListAsync();
                return new ListInvoiceDetailRs()
                {
                    InvoiceDetails = invoiceDetails.MapTo<List<InvoiceDetailDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetInvoiceDetailRs> GetInvoiceDetail(GetInvoiceDetailRq rq)
        {
            try
            {
                InvoiceDetail invoiceDetail = await _invoiceDetailsRepository.GetAsync(rq.Id);

                return new GetInvoiceDetailRs()
                {
                    InvoiceDetail = invoiceDetail.MapTo<InvoiceDetailDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateInvoiceDetailRs> CreateInvoiceDetail(CreateInvoiceDetailRq rq)
        {
            try
            {
                InvoiceDetail insertInvoiceDetail = rq.InvoiceDetail.MapTo<InvoiceDetail>();
                insertInvoiceDetail = await _invoiceDetailsRepository.InsertAsync(insertInvoiceDetail);

                return new CreateInvoiceDetailRs()
                {
                    InvoiceDetail = insertInvoiceDetail.MapTo<InvoiceDetailDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateInvoiceDetailRs> UpdateInvoiceDetail(UpdateInvoiceDetailRq rq)
        {
            try
            {
                InvoiceDetail updateInvoiceDetail = rq.InvoiceDetail.MapTo<InvoiceDetail>();
                updateInvoiceDetail = await _invoiceDetailsRepository.UpdateAsync(updateInvoiceDetail);

                return new UpdateInvoiceDetailRs()
                {
                    InvoiceDetail = updateInvoiceDetail.MapTo<InvoiceDetailDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteInvoiceDetailRs> DeleteInvoiceDetail(DeleteInvoiceDetailRq rq)
        {
            try
            {
                InvoiceDetail deleteInvoiceDetail = rq.InvoiceDetail.MapTo<InvoiceDetail>();
                await _invoiceDetailsRepository.DeleteAsync(deleteInvoiceDetail);

                return new DeleteInvoiceDetailRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
