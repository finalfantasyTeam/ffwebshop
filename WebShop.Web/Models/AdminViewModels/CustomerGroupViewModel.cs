using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class CustomerGroupViewModel
    {
        private readonly ICustomerGroupAppService _GroupAppService;

        public CustomerGroupViewModel(ICustomerGroupAppService GroupAppService)
        {
            _GroupAppService = GroupAppService;
        }

        public async Task FillDataForModel()
        {
            ListCustomerGroup = (await _GroupAppService.GetAllGroup()).Groups;
        }

        public async Task GetCustomerGroup(int id)
        {
            GetCustomerGroupRq rq = new GetCustomerGroupRq()
            { Id = id };
            CustomerGroup = (await _GroupAppService.GetGroupById(rq)).Group;
        }

        public async Task CreateNewCustomerGroup()
        {
            CreateCustomerGroupRq rq = new CreateCustomerGroupRq()
            { Group = CustomerGroup };
            CustomerGroup = (await _GroupAppService.CreateGroup(rq)).Group;
        }

        public async Task UpdateCustomerGroup()
        {
            UpdateCustomerGroupRq rq = new UpdateCustomerGroupRq()
            { Group = CustomerGroup };
            CustomerGroup = (await _GroupAppService.UpdateGroup(rq)).Group;
        }

        public async Task DeleteCustomerGroup()
        {
            DeleteCustomerGroupRq rq = new DeleteCustomerGroupRq()
            { Group = CustomerGroup };
            await _GroupAppService.DeleteGroup(rq);
        }

        public IList<CustomerGroupDTO> ListCustomerGroup { get; set; }
        public CustomerGroupDTO CustomerGroup { get; set; }
    }
}