using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
    public class ProductConunt:BaseSpecifications<Product,int>
    {
        public ProductConunt(ProductSpecParams param) : base(p =>
            (!param.brandid.HasValue || p.BrandId == param.brandid) && (!param.typeid.HasValue || p.TypeId == param.typeid)
            )
        { }
        }
}
