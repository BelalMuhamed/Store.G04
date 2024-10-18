using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Store.G04.Core.Repositories.Contract.Cache;
using System.CodeDom.Compiler;
using System.Text;

namespace Store.G04.APIs.Caching
{
    public class Cached : Attribute, IAsyncActionFilter
    {
        private readonly int _expireTimeInSeconds;

        public Cached(int ExpireTimeInSeconds)
        {
            _expireTimeInSeconds = ExpireTimeInSeconds;
        }
        public async  Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           var cacheservice= context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var Key = GeneratedCacheKeyFromRequest(context.HttpContext.Request);
           var CacheResponse=await cacheservice.GetCacheKeyAsync(Key);
            if (!CacheResponse.IsNullOrEmpty()) 
            {
                var contentResult = new ContentResult()
                {
                    Content = CacheResponse,
                    ContentType = "application/json",
                    StatusCode=200
                };
                context.Result=contentResult;
                return;
            }
           var ExecutedContext=await  next.Invoke();
            if (ExecutedContext.Result is OkObjectResult result) 
            {
                 await  cacheservice.SetDataInCacheAsync(Key, result.Value, TimeSpan.FromHours(_expireTimeInSeconds));
            }
        }

        private string GeneratedCacheKeyFromRequest(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();
            KeyBuilder.Append(request.Path);
            foreach(var(key,value) in request.Query.OrderBy(x => x.Key))
            {
                KeyBuilder.Append($"|{key}-{value}");
            }
            return KeyBuilder.ToString();   
        }
    }
}
