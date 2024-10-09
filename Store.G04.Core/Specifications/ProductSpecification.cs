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
        public ProductSpecification()
        {
            addincludes();
        }
        private void addincludes()
        {
            Includes.Add(p =>p.Brand);
            Includes.Add(p =>p.Type);
        }
    }
}
