using Abp.Application.Services.Dto;
using System;

namespace WebShop.Application
{
    public class GetUsersRq : BaseRequest
    {
        public Guid UserId { get; set; }
    }
}
