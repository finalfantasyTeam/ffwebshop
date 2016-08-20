using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListInvoiceRs : BaseResponse<InvoiceDTO>
    {
        public List<InvoiceDTO> Invoices { get; set; }
    }
}
