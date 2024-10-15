using Microsoft.Extensions.Primitives;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repositories.Contract
{
    public interface IBasketRepository
    {
        public  Task<bool> DeleteBasketAsync(string BasketId);
        public Task<CustomerBasket?> GetBasketAsync(string BasketId);
        public Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
    }
}
