using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.DTOs.ProductDto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public string PictureUrl { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
