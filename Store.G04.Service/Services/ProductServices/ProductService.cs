using AutoMapper;
using Store.G04.Core.DTOs.ProductDto;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Services.Contract;
using Store.G04.Core.Specifications;
using Store.G04.Repository.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Service.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitofwork,IMapper mapper)
        {
           _unitofwork = unitofwork;
            _mapper = mapper;
        }
        //GetAllBrandsAsync
        public async  Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
           => _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitofwork.Repositorey<ProductBrand, int>().GetAllAsync());
        
           
        //GetAllProductsAsync
        public async Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams param)
        {
            var spec = new ProductSpecification(param);
            
            var products = await _unitofwork.Repositorey<Product, int>().GetAllWithSpecificAsync(spec);
            var mapped = _mapper.Map<IEnumerable<ProductDto>>(products);
            var countt = new ProductConunt(param);
           var count = await _unitofwork.Repositorey<Product, int>().GetCountAsync(countt);
            return new PaginationResponse<ProductDto>(param.pagesize, param.pageindex, count, mapped);
        }
        //GetAllTypesAsync
        public async  Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
        => _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitofwork.Repositorey<ProductType, int>().GetAllAsync());
        //GetProductById
        public async Task<ProductDto> GetProductById(int Id)
        {
            var Spec = new ProductSpecification(Id);

        return  _mapper.Map<ProductDto>(await _unitofwork.Repositorey<Product, int>().GetWithSpecificAsync(Spec));
        }
       
    }
}
