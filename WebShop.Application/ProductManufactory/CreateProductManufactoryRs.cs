using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class CreateProductManufactoryRs : IOutputDto
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
