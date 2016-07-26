using AutoMapper;
using WebShop;
using WebShop.Core;

namespace WebShop.Application
{
    internal static class DtoMapping
    {
        public static void Map()
        {
            // Mapping Product Manufactory
            Mapper.CreateMap<ProductManufactory, ProductManufactoryDTO>();
            Mapper.CreateMap<ProductManufactoryDTO, ProductManufactory>();
        }
    }
}