using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class CustomerOrderViewModel
    {
        private readonly ICustomerOrderAppService _OrderAppService;

        public CustomerOrderViewModel()
        {
        }

        public CustomerOrderViewModel(ICustomerOrderAppService OrderAppService)
        {
            _OrderAppService = OrderAppService;
        }

        public async Task FillDataForModel()
        {
            ListCustomerOrder = (await _OrderAppService.GetAllOrder()).Orders;
        }

        public async Task GetCustomerOrder(int id)
        {
            GetCustomerOrderRq rq = new GetCustomerOrderRq()
            { Id = id };
            CustomerOrder = (await _OrderAppService.GetOrderById(rq)).Order;
        }

        public async Task CreateNewCustomerOrder()
        {
            CreateCustomerOrderRq rq = new CreateCustomerOrderRq()
            { Order = CustomerOrder };
            CustomerOrder = (await _OrderAppService.CreateOrder(rq)).Order;
        }

        public async Task UpdateCustomerOrder()
        {
            UpdateCustomerOrderRq rq = new UpdateCustomerOrderRq()
            { Order = CustomerOrder };
            CustomerOrder = (await _OrderAppService.UpdateOrder(rq)).Order;
        }

        public async Task DeleteCustomerOrder()
        {
            DeleteCustomerOrderRq rq = new DeleteCustomerOrderRq()
            { Order = CustomerOrder };
            await _OrderAppService.DeleteOrder(rq);
        }
        public IList<CustomerOrderDTO> ListCustomerOrder { get; set; }
        public CustomerOrderDTO CustomerOrder { get; set; }
    }
}