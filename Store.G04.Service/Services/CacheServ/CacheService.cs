using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
using Store.G04.Core.Repositories.Contract.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G04.Service.Services.CacheServ
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _Database;

        public CacheService(IConnectionMultiplexer redis)
        {
            _Database = redis.GetDatabase();
        }
        public async Task<string> GetCacheKeyAsync(string Key)
        {
            var response = await _Database.StringGetAsync(Key);
            if (response.IsNullOrEmpty) return null;
            else { return response.ToString(); }
        }

        public async Task<bool> SetDataInCacheAsync(string key, object Response, TimeSpan ExpiredTime)
        {
            if(Response == null) { return false; }
            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

           return await _Database.StringSetAsync(key, JsonSerializer.Serialize(Response,options), ExpiredTime);

            
        }
    }
}
