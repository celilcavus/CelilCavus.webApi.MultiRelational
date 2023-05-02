using AutoMapper;
using CelilCavus.Dto.OrderDto;
using CelilCavus.Entitys;

namespace CelilCavus.Mapping.OrderMapping
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order,OrderListDto>().ReverseMap();
            CreateMap<Order,OrderAddDto>().ReverseMap();
            CreateMap<Order,OrderPutDto>().ReverseMap();
            CreateMap<Order,OrderDeleteDto>().ReverseMap();
        }
    }
}