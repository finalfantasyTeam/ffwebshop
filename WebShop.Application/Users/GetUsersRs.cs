using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class GetUsersRs : BaseResponse<UsersDTO>
    {
        public UsersDTO User { get; set; }
    }
}
