using AutoMapper;
using CelilCavus.Dto.CustomerDto;
using CelilCavus.Entitys;

namespace CelilCavus.Mapping
{
    public class CustomerMapping:Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer,CustomerListDto>().ReverseMap();
            CreateMap<Customer,CustomerAddDto>().ReverseMap();
            CreateMap<Customer,CustomerRemoveDto>().ReverseMap();
            CreateMap<Customer,CustomerUpdateDto>().ReverseMap();
        }
    }
}