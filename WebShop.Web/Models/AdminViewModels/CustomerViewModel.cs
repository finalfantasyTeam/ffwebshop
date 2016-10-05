using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class CustomerViewModel
    {
        private readonly ICustomerAppService _CustomerAppService;

        public CustomerViewModel()
        {
        }

        public CustomerViewModel(ICustomerAppService CustomerAppService)
        {
            _CustomerAppService = CustomerAppService;
        }

        public async Task FillDataForModel()
        {
            ListCustomer = (await _CustomerAppService.GetAllCustomer()).Customers;
        }

        public async Task GetCustomer(int id)
        {
            GetCustomerRq rq = new GetCustomerRq()
            { Id = id };
            Customer = (await _CustomerAppService.GetCustomerById(rq)).Customer;
        }

        public async Task CreateNewCustomer()
        {
            CreateCustomerRq rq = new CreateCustomerRq()
            { Customer = Customer };
            Customer = (await _CustomerAppService.CreateCustomer(rq)).Customer;
        }

        public async Task UpdateCustomer()
        {
            UpdateCustomerRq rq = new UpdateCustomerRq()
            { Customer = Customer };
            Customer = (await _CustomerAppService.UpdateCustomer(rq)).Customer;
        }

        public async Task DeleteCustomer()
        {
            DeleteCustomerRq rq = new DeleteCustomerRq()
            { Customer = Customer };
            await _CustomerAppService.DeleteCustomer(rq);
        }
        public IList<CustomerDTO> ListCustomer { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}