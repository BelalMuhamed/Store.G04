using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repositories.Contract.Cache
{
    public interface ICacheService
    {
        public Task SetDataInCacheAsync(string key, object Response, TimeSpan ExpiredTime);
        public Task<string> GetCacheKeyAsync(string Key);
    }
}
