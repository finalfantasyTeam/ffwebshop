using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class CreateUsersRq : BaseRequest
    {
        public UsersDTO User { get; set; }
    }
}