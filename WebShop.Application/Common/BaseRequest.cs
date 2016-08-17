using System;
using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public abstract class BaseRequest : IPagedResultRequest
    {
        public virtual int MaxResultCount { get; set; }
        public virtual int SkipCount { get; set; }
    }
}
