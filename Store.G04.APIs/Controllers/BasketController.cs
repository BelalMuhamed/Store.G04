using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;

namespace Store.G04.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketrepo;

        public BasketController(IBasketRepository basketrepo)
        {
            _basketrepo = basketrepo;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id)
        {
            return await _basketrepo.DeleteBasketAsync(id);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetOrRecreateBasket(string id)
        {
            var basket =await  _basketrepo.GetBasketAsync(id);
            if (basket == null) { return Ok(new CustomerBasket(id)); }
            else
            {
                return Ok(basket);
            }
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateOrCreateBasket(CustomerBasket basket)
        {
            var CreateOrUpdate =await  _basketrepo.UpdateBasketAsync(basket);
            if (CreateOrUpdate == null) { return BadRequest(new ApiResponse(400)); }
            else return Ok(CreateOrUpdate);
        }
    }
}