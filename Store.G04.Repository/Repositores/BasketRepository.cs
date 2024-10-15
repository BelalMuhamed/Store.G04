using StackExchange.Redis;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G04.Repository.Repositores
{
    internal class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _context;

        public BasketRepository(IConnectionMultiplexer context)
        {
            _context = context.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
            return await _context.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string BasketId)
        {
            var Basket =await  _context.StringGetAsync(BasketId);
            if(Basket.IsNull) return null;
            else
            {
                return JsonSerializer.Deserialize<CustomerBasket>(Basket);
            }
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var SerilzedBasket = JsonSerializer.Serialize(basket);
            var UpdatedBasket =await  _context.StringSetAsync(basket.Id,SerilzedBasket,TimeSpan.FromDays(1));
            if (!UpdatedBasket) return null;
            else
            {
                return await GetBasketAsync(basket.Id);
            }
        }
    }
}
