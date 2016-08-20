using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class ListUsersRs : BaseResponse<UsersDTO>
    {
        public List<UsersDTO> Users { get; set; }
    }
}
