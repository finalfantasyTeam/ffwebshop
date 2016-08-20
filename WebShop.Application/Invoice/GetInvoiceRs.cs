using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class GetInvoiceRs : BaseResponse<InvoiceDTO>
    {
        public InvoiceDTO Invoice { get; set; }
    }
}
