using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class CustomerStatusViewModel
    {
        private readonly ICustomerStatusAppService _StatusAppService;

        public CustomerStatusViewModel()
        {
        }

        public CustomerStatusViewModel(ICustomerStatusAppService StatusAppService)
        {
            _StatusAppService = StatusAppService;
        }

        public async Task FillDataForModel()
        {
            ListCustomerStatus = (await _StatusAppService.GetAllStatus()).Statuses;
        }

        public async Task GetCustomerStatus(int id)
        {
            GetCustomerStatusRq rq = new GetCustomerStatusRq()
            { Id = id };
            CustomerStatus = (await _StatusAppService.GetStatusById(rq)).Status;
        }

        public async Task CreateNewCustomerStatus()
        {
            CreateCustomerStatusRq rq = new CreateCustomerStatusRq()
            { Status = CustomerStatus };
            CustomerStatus = (await _StatusAppService.CreateStatus(rq)).Status;
        }

        public async Task UpdateCustomerStatus()
        {
            UpdateCustomerStatusRq rq = new UpdateCustomerStatusRq()
            { Status = CustomerStatus };
            CustomerStatus = (await _StatusAppService.UpdateStatus(rq)).Status;
        }

        public async Task DeleteCustomerStatus()
        {
            DeleteCustomerStatusRq rq = new DeleteCustomerStatusRq()
            { Status = CustomerStatus };
            await _StatusAppService.DeleteStatus(rq);
        }
        public IList<CustomerStatusDTO> ListCustomerStatus { get; set; }
        public CustomerStatusDTO CustomerStatus { get; set; }
    }
}