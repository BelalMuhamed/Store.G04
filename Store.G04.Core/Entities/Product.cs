using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Entities
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Descreption { get; set; }
        public string PictureUrl { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int? BrandId { get; set; }
        public ProductBrand Brand { get; set; }
        public int? TypeId { get; set; }
        public ProductType Type { get; set; }

    }
}
