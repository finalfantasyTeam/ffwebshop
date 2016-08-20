using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class GetInvoiceDetailRs : BaseResponse<InvoiceDetailDTO>
    {
        public InvoiceDetailDTO InvoiceDetail { get; set; }
    }
}
