using AutoMapper;
using CelilCavus.Dto.VehicleDto;
using CelilCavus.Entitys;

namespace CelilCavus.Mapping.OrderMapping
{
    public class VehicleMapping:Profile
    {
        public VehicleMapping()
        {
            CreateMap<Vehicle,VehicleListDto>().ReverseMap();
            CreateMap<Vehicle,VehicleAddDto>().ReverseMap();
            CreateMap<Vehicle,VehicleDeleteDto>().ReverseMap();
            CreateMap<Vehicle,VehiclePutDto>().ReverseMap();
        }
    }
}