using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Store.G04.Core.DTOs.ProductDto;
using Store.G04.Core.Services.Contract;
using Store.G04.Core.Specifications;
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
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecParams param)
        { 
             var result =await _service.GetAllProductsAsync(param);
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
            if(result == null) return NotFound(new ApiResponse(404));
            return Ok(result);
        }
    }
}
