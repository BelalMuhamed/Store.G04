using Microsoft.IdentityModel.Tokens;
using Store.G04.Core.Entities;
using Store.G04.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G04.Repository.Data
{
    public static class StoreDbContextSeeds
    {
        public async static  Task SeedAsync(StoreDbContext _context)
        {
            if(_context.Brands.IsNullOrEmpty())
            {
                var BrandData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                if(brands is not null)
                {
                    await _context.Brands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();

                }

            }
            if (_context.Types.IsNullOrEmpty())
            {
                var TypeData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                if (Types is not null)
                {
                    await _context.Types.AddRangeAsync(Types);
                    await _context.SaveChangesAsync();

                }

            }
            if (_context.Products.IsNullOrEmpty())
            {
                var ProductsData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products is not null)
                {
                    await _context.Products.AddRangeAsync(Products);
                    await _context.SaveChangesAsync();

                }

            }

        }
    }
}
