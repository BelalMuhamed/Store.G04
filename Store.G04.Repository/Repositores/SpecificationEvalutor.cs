using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.G04.Core.Entities;
using Store.G04.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository.Repositores
{
    public static class SpecificationEvalutor<TEntity,TKEy> where TEntity : BaseEntity<TKEy>
    {
        public static IQueryable<TEntity> CreateQuery(IQueryable<TEntity> InputQuery, ISpecifications<TEntity, TKEy> Spec)
        {
            var Query = InputQuery;
            if (Spec.Criteria is not null)
            {
                Query = Query.Where(Spec.Criteria);
            }
            if(Spec.OrderBy is not null)
            {
                Query=Query.OrderBy(Spec.OrderBy);
            }
            if (Spec.IsPagination == true) 
            {
                Query=Query.Skip(Spec.Skip).Take(Spec.Take);    
            }
            Query = Spec.Includes.Aggregate(Query, (CuurentQuery, includeExpression) => CuurentQuery.Include(includeExpression));
            return Query;
        }
    }
}
