using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Repository.Data.Context;

namespace Store.G04.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyControlller : ControllerBase
    {
        private readonly StoreDbContext _context;

        public BuggyControlller(StoreDbContext context)
        {
            _context = context;
        }
        [HttpGet("NotFound")]
        public async Task<IActionResult> GetNotFoundRequest() 
        {
            var product =await  _context.Products.FindAsync(100);
            if (product is null) { return NotFound(); }
            return Ok(product);
        }
        [HttpGet("ServerError")]
        public IActionResult GetServerError() 
        { 
            var product = _context.Products.Find(100);
            var ProductToString = product.ToString();
            return Ok(ProductToString);
        }
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("BadRequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
