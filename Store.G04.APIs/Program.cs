
using Microsoft.EntityFrameworkCore;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Repository.Data;
using Store.G04.Repository.Data.Context;
using Store.G04.Repository.Repositores;
using Store.G04.Service.Services.ProductServices;
using AutoMapper;
using Store.G04.Core.Profiles;
using Store.G04.Core.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Store.G04.APIs.MidleWareException;
using Store.G04.APIs.Extensions;
using StackExchange.Redis;

namespace Store.G04.APIs
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var connection = builder.Configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(connection);
            });
            //allow dependency injection to open the connection with data base 
            builder.Services.AddDbContext<StoreDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAppServices(builder.Configuration);
            var app = builder.Build();
          using var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;
            var Context = Services.GetRequiredService<StoreDbContext>();
            var LoggerFactory =Services.GetRequiredService<ILoggerFactory>();
            try
            {
                await Context.Database.MigrateAsync();
                await StoreDbContextSeeds.SeedAsync(Context);

            }
            catch (Exception ex)
            {
                var logger =LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "there is an error ");
            }
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<ExceptionMiddleWare>();
                app.AddSwagger();
            }
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
