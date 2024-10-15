using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Store.G04.Core.Profiles;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Services.Contract;
using Store.G04.Repository.Repositores;
using Store.G04.Service.Services.ProductServices;

namespace Store.G04.APIs.Extensions
{
    public static  class AppServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection Services,IConfiguration Configuration)
        {
           Services.AddScoped<IProductService, ProductService>();
           Services.AddScoped<IUnitOfWork, UnitOfWork>();
           Services.AddAutoMapper(m => m.AddProfile(new ProductProfile(Configuration)));
           Services.Configure<ApiBehaviorOptions>(options =>
            options.InvalidModelStateResponseFactory = (actioncontext) =>
            {
                var errors = actioncontext.ModelState.Where(p => p.Value.Errors.Count() > 0).SelectMany(p => p.Value.Errors)
                .Select(e => e.ErrorMessage).ToArray();
                var ValidationErrorResponse = new ApiValidationErrorResponse()
                {
                    Errors = errors
                };
                return new BadRequestObjectResult(ValidationErrorResponse);
            });
            return Services;
        }
       
    }
}
