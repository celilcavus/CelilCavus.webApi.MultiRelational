using AutoMapper;
using CelilCavus.Dto.OrderDto;
using CelilCavus.Entitys;
using CelilCavus.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _map;
        private readonly IUow _uow;

        public OrderController(IMapper map, IUow uow)
        {
            _map = map;
            _uow = uow;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {
            var OrderListValues = await _uow.GetRepository<Order>().GetList();
            var OrderList = _map.Map<List<OrderListDto>>(OrderListValues);
            if (OrderList is null)
            {
                return Ok(Enumerable.Empty<OrderListDto>());
            }
            return Ok(OrderList);
        }

        [HttpPost]
        public IActionResult PostOrder(OrderAddDto order)
        {
            var OrderMapping = _map.Map<Order>(order);
            _uow.GetRepository<Order>().Add(OrderMapping);
            _uow.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderList(int id)
        {
            var OrderListValues = await _uow.GetRepository<Order>().GetById(id);
            var OrderList = _map.Map<List<OrderListDto>>(OrderListValues);
            if (OrderList is null)
            {
                return Ok(Enumerable.Empty<OrderListDto>());
            }
            return Ok(OrderList);
        }

        [HttpPut]
        public IActionResult PutOrder(OrderPutDto orderPut)
        {
            var putdto = _map.Map<Order>(orderPut);
            _uow.GetRepository<Order>().Update(putdto);
            _uow.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(OrderDeleteDto order)
        {
            var deleteDto = _map.Map<Order>(order);
            var RemoveOrder = await _uow.GetRepository<Order>().GetById(deleteDto.Id);

            _uow.GetRepository<Order>().Delete(RemoveOrder);
            _uow.SaveChanges();
            return NoContent();
        }
    }
}