using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateUsersRq : BaseRequest
    {
        public UsersDTO User { get; set; }
    }
}
