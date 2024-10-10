﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
    public class ProductSpecParams
    {
        
            public string? sort { get; set; }
        public int? brandid { get; set; }
        public int? typeid { get; set; }
        public int pagesize { get; set; } = 5;
        public int pageindex { get; set; } = 1;

    }
}
