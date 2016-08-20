using Abp.Application.Services;
using System.Threading.Tasks;

namespace WebShop.Application
{
    public interface IInvoiceAppService : IApplicationService
    {
        Task<ListInvoiceRs> GetAllInvoices();
        Task<GetInvoiceRs> GetInvoice(GetInvoiceRq rq);
        Task<CreateInvoiceRs> CreateInvoice(CreateInvoiceRq rq);
        Task<UpdateInvoiceRs> UpdateInvoice(UpdateInvoiceRq rq);
        Task<DeleteInvoiceRs> DeleteInvoice(DeleteInvoiceRq rq);
    }
}
