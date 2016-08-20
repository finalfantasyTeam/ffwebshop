using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Core;

namespace WebShop.Application
{
    public class InvoiceAppService : IInvoiceAppService
    {
        private readonly IInvoiceRepository _configOptionsRepository;

        public InvoiceAppService(IInvoiceRepository configOptionsRepository)
        {
            _configOptionsRepository = configOptionsRepository;
            Mapper.CreateMap<Invoice, InvoiceDTO>();
            Mapper.CreateMap<InvoiceDTO, Invoice>();
        }

        public async Task<ListInvoiceRs> GetAllInvoices()
        {
            try
            {
                List<Invoice> configOptions = await _configOptionsRepository.GetAllListAsync();
                return new ListInvoiceRs()
                {
                    Invoices = configOptions.MapTo<List<InvoiceDTO>>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetInvoiceRs> GetInvoice(GetInvoiceRq rq)
        {
            try
            {
                Invoice configOption = await _configOptionsRepository.GetAsync(rq.Id);

                return new GetInvoiceRs()
                {
                    Invoice = configOption.MapTo<InvoiceDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreateInvoiceRs> CreateInvoice(CreateInvoiceRq rq)
        {
            try
            {
                Invoice insertInvoice = rq.Invoice.MapTo<Invoice>();
                insertInvoice = await _configOptionsRepository.InsertAsync(insertInvoice);

                return new CreateInvoiceRs()
                {
                    Invoice = insertInvoice.MapTo<InvoiceDTO>()
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
                Invoice updateInvoice = rq.Invoice.MapTo<Invoice>();
                updateInvoice = await _configOptionsRepository.UpdateAsync(updateInvoice);

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
                await _configOptionsRepository.DeleteAsync(deleteInvoice);

                return new DeleteInvoiceRs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
