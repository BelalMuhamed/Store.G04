using Store.G04.Core.DTOs.ProductDto;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
    
    public  class PaginationResponse<TEntity>
    {
        public PaginationResponse(int pageSize, int index, int count, IEnumerable<TEntity> data)
        {
            PageSize = pageSize;
            Index = index;
            Count = count;
            Data = data;
        }

        
        public int PageSize { get; set; }
        public  int Index { get; set; }
        public int Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
       
    }
}
