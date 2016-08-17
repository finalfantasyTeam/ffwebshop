using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public abstract class BaseResponse<TDto> : IPagedResult<TDto>
    {
        public virtual IReadOnlyList<TDto> Items { get; set; }
        public virtual int TotalCount { get; set; }
    }
}
