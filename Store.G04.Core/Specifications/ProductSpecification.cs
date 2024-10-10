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
        public ProductSpecification(int id):base( p =>p.Id==id)
        {
            addincludes();
        }
        public ProductSpecification(string? sort, int? brandid, int? typeid,int pagesize,int pageindex):base( p=>
            (!brandid.HasValue||p.BrandId==brandid)&&(!typeid.HasValue||p.TypeId==typeid)
            )
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
            addpaginagtion(pagesize*(pageindex-1),  pagesize);
        }
        private void addincludes()
        {
            Includes.Add(p =>p.Brand);
            Includes.Add(p =>p.Type);
        }
        
    }
}
