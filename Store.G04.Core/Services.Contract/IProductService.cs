using Store.G04.Core.DTOs.ProductDto;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Services.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? sort,int? brandid,int?typeid,int?size,int?index);
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<ProductDto> GetProductById(int Id);

    }
}
