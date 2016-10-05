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
    public class InvoiceAppService : IInvoiceAppService
    {
        private readonly IInvoiceRepository _InvoiceRepository;

        private static string SetDefaultImage(string value)
        {
            return "";
        }

        public InvoiceAppService(IInvoiceRepository InvoiceRepository)
        {
            _InvoiceRepository = InvoiceRepository;
            Mapper.CreateMap<InvoiceDTO, Invoice>();
            Mapper.CreateMap<Invoice, InvoiceDTO>();
        }

        public async Task<ListInvoiceRs> GetAllInvoices()
        {
            try
            {
                List<Invoice> Invoices = await _InvoiceRepository.GetAllListAsync();
                return new ListInvoiceRs()
                {
                    Invoices = Invoices.MapTo<List<InvoiceDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetInvoiceRs> GetInvoiceById(GetInvoiceRq rq)
        {
            Invoice Invoice = await _InvoiceRepository.GetAsync(rq.Id);

            return new GetInvoiceRs()
            {
                Invoice = Invoice.MapTo<InvoiceDTO>()
            };
        }

        public async Task<CreateInvoiceRs> CreateInvoice(CreateInvoiceRq rq)
        {
            try
            {
                rq.Invoice.CreateDate = DateTime.Now;
                Invoice insertInvoice = rq.Invoice.MapTo<Invoice>();
                rq.Invoice.Id = await _InvoiceRepository.InsertAndGetIdAsync(insertInvoice);

                return new CreateInvoiceRs()
                {
                    Invoice = rq.Invoice
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateInvoiceRs> UpdateInvoice(UpdateInvoiceRq rq)
        {
            try
            {
                rq.Invoice.UpdateDate = DateTime.Now;
                Invoice updateInvoice = rq.Invoice.MapTo<Invoice>();
                updateInvoice = await _InvoiceRepository.UpdateAsync(updateInvoice);

                return new UpdateInvoiceRs()
                {
                    Invoice = updateInvoice.MapTo<InvoiceDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeleteInvoiceRs> DeleteInvoice(DeleteInvoiceRq rq)
        {
            try
            {
                Invoice deleteInvoice = rq.Invoice.MapTo<Invoice>();
                await _InvoiceRepository.DeleteAsync(deleteInvoice);

                return new DeleteInvoiceRs()
                {
                    Invoice = deleteInvoice.MapTo<InvoiceDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
