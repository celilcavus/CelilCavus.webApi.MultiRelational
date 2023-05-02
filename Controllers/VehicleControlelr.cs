using AutoMapper;
using CelilCavus.Dto.VehicleDto;
using CelilCavus.Entitys;
using CelilCavus.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VehicleController : ControllerBase
    {
         private readonly IMapper _map;
        private readonly IUow _uow;

        public VehicleController(IMapper map, IUow uow)
        {
            _map = map;
            _uow = uow;
        }


        [HttpGet]
        public async Task<IActionResult> GetVehicleList()
        {
            var VehicleListValues = await _uow.GetRepository<Vehicle>().GetList();
            var VehicleList = _map.Map<List<VehicleListDto>>(VehicleListValues);
            if (VehicleList is null)
            {
                return Ok(Enumerable.Empty<VehicleListDto>());
            }
            return Ok(VehicleList);
        }

        [HttpPost]
        public IActionResult PostVehicle(VehicleAddDto Vehicle)
        {
            var VehicleMapping = _map.Map<Vehicle>(Vehicle);
            _uow.GetRepository<Vehicle>().Add(VehicleMapping);
            _uow.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleList(int id)
        {
            var VehicleListValues = await _uow.GetRepository<Vehicle>().GetById(id);
            var VehicleList = _map.Map<List<VehicleListDto>>(VehicleListValues);
            if (VehicleList is null)
            {
                return Ok(Enumerable.Empty<VehicleListDto>());
            }
            return Ok(VehicleList);
        }

        [HttpPut]
        public IActionResult PutVehicle(VehiclePutDto VehiclePut)
        {
            var putdto = _map.Map<Vehicle>(VehiclePut);
            _uow.GetRepository<Vehicle>().Update(putdto);
            _uow.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(VehicleDeleteDto Vehicle)
        {
            var deleteDto = _map.Map<Vehicle>(Vehicle);
            var RemoveVehicle = await _uow.GetRepository<Vehicle>().GetById(deleteDto.Id);

            _uow.GetRepository<Vehicle>().Delete(RemoveVehicle);
            _uow.SaveChanges();
            return NoContent();
        }
    }
}