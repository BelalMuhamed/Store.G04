﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.DTOs.ProductDto
{
    public class TypeBrandDto
    {
        public string Name { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
