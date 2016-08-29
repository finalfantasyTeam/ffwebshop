using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace WebShop.Application
{
    public class DeleteProductManufactoryRs : BaseResponse<ProductManufactoryDTO>
    {
        public ProductManufactoryDTO Manufactory { get; set; }
    }
}
