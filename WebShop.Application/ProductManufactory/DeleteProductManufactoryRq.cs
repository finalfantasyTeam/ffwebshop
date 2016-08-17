using System;
using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class DeleteProductManufactoryRq : BaseRequest
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
