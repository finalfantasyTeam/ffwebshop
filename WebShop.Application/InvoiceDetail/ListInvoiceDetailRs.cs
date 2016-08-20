using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListInvoiceDetailRs : BaseResponse<InvoiceDetailDTO>
    {
        public List<InvoiceDetailDTO> InvoiceDetails { get; set; }
    }
}
