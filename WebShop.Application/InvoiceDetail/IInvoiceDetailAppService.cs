using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IInvoiceDetailAppService : IApplicationService
    {
        Task<ListInvoiceDetailRs> GetAllInvoiceDetails();
        Task<GetInvoiceDetailRs> GetInvoiceDetail(GetInvoiceDetailRq rq);
        Task<CreateInvoiceDetailRs> CreateInvoiceDetail(CreateInvoiceDetailRq rq);
        Task<UpdateInvoiceDetailRs> UpdateInvoiceDetail(UpdateInvoiceDetailRq rq);
        Task<DeleteInvoiceDetailRs> DeleteInvoiceDetail(DeleteInvoiceDetailRq rq);
    }
}
