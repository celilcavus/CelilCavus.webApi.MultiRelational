using AutoMapper;
using CelilCavus.Dto.ProductDto;
using CelilCavus.Entitys;
using CelilCavus.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
         private readonly IMapper _map;
        private readonly IUow _uow;

        public ProductController(IMapper map, IUow uow)
        {
            _map = map;
            _uow = uow;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var ProductListValues = await _uow.GetRepository<Product>().GetList();
            var ProductList = _map.Map<List<ProductListDto>>(ProductListValues);
            if (ProductList is null)
            {
                return Ok(Enumerable.Empty<ProductListDto>());
            }
            return Ok(ProductList);
        }

        [HttpPost]
        public IActionResult PostProduct(ProductAddDto Product)
        {
            var ProductMapping = _map.Map<Product>(Product);
            _uow.GetRepository<Product>().Add(ProductMapping);
            _uow.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductList(int id)
        {
            var ProductListValues = await _uow.GetRepository<Product>().GetById(id);
            var ProductList = _map.Map<List<ProductListDto>>(ProductListValues);
            if (ProductList is null)
            {
                return Ok(Enumerable.Empty<ProductListDto>());
            }
            return Ok(ProductList);
        }

        [HttpPut]
        public IActionResult PutProduct(ProductPutDto ProductPut)
        {
            var putdto = _map.Map<Product>(ProductPut);
            _uow.GetRepository<Product>().Update(putdto);
            _uow.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(ProductDeleteDto Product)
        {
            var deleteDto = _map.Map<Product>(Product);
            var RemoveProduct = await _uow.GetRepository<Product>().GetById(deleteDto.Id);

            _uow.GetRepository<Product>().Delete(RemoveProduct);
            _uow.SaveChanges();
            return NoContent();
        }
    }
}