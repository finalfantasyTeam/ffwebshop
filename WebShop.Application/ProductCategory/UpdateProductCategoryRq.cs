﻿using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class UpdateProductCategoryRq : BaseRequest
    {
        public ProductCategoryDTO Category { get; set; }
    }
}
