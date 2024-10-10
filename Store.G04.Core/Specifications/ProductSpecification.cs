using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
    public class ProductSpecification:BaseSpecifications<Product,int>
    {
        public ProductSpecification( int id):base( p =>p.Id==id)
        {
            addincludes();
        }
        public ProductSpecification(ProductSpecParams param) :base( p=>
            (!param.brandid.HasValue||p.BrandId== param.brandid) &&(!param.typeid.HasValue||p.TypeId== param.typeid)
            )
        {
            if (!string.IsNullOrEmpty(param.sort))
            {
                switch (param.sort)
                {
                  
                        
                    case "priceasc":
                        OrderBy = p => p.Price;
                        break;
                    default:
                        OrderBy = p => p.Name;
                        break;
                }
            }
            else
            {
                OrderBy = p => p.Name;
                
            }
            addincludes();
            addpaginagtion(param.pagesize*(param.pageindex-1),  param.pagesize);
        }
        private void addincludes()
        {
            Includes.Add(p =>p.Brand);
            Includes.Add(p =>p.Type);
        }
        
    }
}
