using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Entities
{
    internal class Product:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Descreption { get; set; }
        public string PictureUrl { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
