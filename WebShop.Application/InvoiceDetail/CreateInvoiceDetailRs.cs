using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateInvoiceDetailRs : BaseResponse<InvoiceDetailDTO>
    {
        public InvoiceDetailDTO InvoiceDetail { get; set; }
    }
}
