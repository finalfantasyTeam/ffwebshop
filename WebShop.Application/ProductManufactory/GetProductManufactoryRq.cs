using Abp.Application.Services.Dto;

namespace WebShop.Application
{
    public class GetProductManufactoryRq : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
