﻿using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductMetaRq : BaseRequest
    {
        public ProductMetaDTO Meta { get; set; }
    }
}
