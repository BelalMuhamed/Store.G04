using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.G04.Core.DTOs.ProductDto;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IConfiguration confi)
        {
            CreateMap<Product, ProductDto>().ForMember(p => p.BrandName, Options => Options.MapFrom(s => s.Brand.Name))
                .ForMember(p => p.TypeName, Options => Options.MapFrom(s => s.Type.Name))
                .ForMember(p => p.PictureUrl,options => options.MapFrom(s => $"{confi["BaseUrl"]}{s.PictureUrl}"));
            CreateMap<ProductBrand, TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>(); 
        }
    }
}
