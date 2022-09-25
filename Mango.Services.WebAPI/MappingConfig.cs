using AutoMapper;
using Mango.Services.WebAPI.Models;
using Mango.Services.WebAPI.Models.Dtos;

namespace Mango.Services.WebAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}