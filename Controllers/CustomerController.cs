using AutoMapper;
using CelilCavus.Dto.CustomerDto;
using CelilCavus.Entitys;
using CelilCavus.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _map;
        private readonly IUow _uow;
        public CustomerController(IMapper map, IUow uow)
        {
            _map = map;
            _uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var getCustomerList = await _uow.GetRepository<Customer>().GetList();
            var values = _map.Map<List<CustomerListDto>>(getCustomerList);
            if (values is  null)
            {
                return Ok(Enumerable.Empty<CustomerListDto>());
            }
            return Ok(values);
        }
        [HttpPost]
        public IActionResult PostCustomer(CustomerAddDto customer)
        {
            var AddCustomer = _map.Map<Customer>(customer);
            _uow.GetRepository<Customer>().Add(AddCustomer);
            _uow.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var GetCustomer = await _uow.GetRepository<Customer>().GetById(id);
            var Customer = _map.Map<CustomerListDto>(GetCustomer);
            return Ok(Customer);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(CustomerRemoveDto removeDto)
        {
            var CustomerRemoveDto = _map.Map<Customer>(removeDto);
            var RemoveCustomer = await _uow.GetRepository<Customer>().GetById(CustomerRemoveDto.Id);
            _uow.GetRepository<Customer>().Delete(RemoveCustomer);
            _uow.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public IActionResult PutCustomer(CustomerUpdateDto customer)
        {
            var PutCustomer = _map.Map<Customer>(customer);
            _uow.GetRepository<Customer>().Update(PutCustomer);
            _uow.SaveChanges();
            return Ok();
        }
    }
}