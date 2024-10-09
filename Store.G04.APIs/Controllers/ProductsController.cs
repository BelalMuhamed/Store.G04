using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Core.Services.Contract;
using System.Collections;

namespace Store.G04.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        { 
             var result =await _service.GetAllProductsAsync();
            return Ok(result);
        }
        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _service.GetAllBrandsAsync();
            return Ok(result);
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _service.GetAllTypesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id ==null) return BadRequest();
            var result = await _service.GetProductById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
