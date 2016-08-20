using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateInvoiceRs : BaseResponse<InvoiceDTO>
    {
        public InvoiceDTO Invoice { get; set; }
    }
}
