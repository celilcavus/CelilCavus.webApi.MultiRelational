using AutoMapper;
using CelilCavus.Dto.ProductDto;
using CelilCavus.Entitys;

namespace CelilCavus.Mapping.OrderMapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ProductListDto>().ReverseMap();
            CreateMap<Product,ProductAddDto>().ReverseMap();
            CreateMap<Product,ProductDeleteDto>().ReverseMap();
            CreateMap<Product,ProductPutDto>().ReverseMap();
        }
    }
}