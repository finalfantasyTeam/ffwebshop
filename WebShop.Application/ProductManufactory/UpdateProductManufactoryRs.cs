using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class UpdateProductManufactoryRs : IOutputDto
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
