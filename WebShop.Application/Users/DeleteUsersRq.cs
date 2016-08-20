using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteUsersRq : BaseRequest
    {
        public UsersDTO User { get; set; }
    }
}
