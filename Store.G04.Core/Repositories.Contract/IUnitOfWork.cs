using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repositories.Contract
{
    public interface IUnitOfWork
    {
       Task<int> CompeleteAsync();
       IGenericRepository<TEntity,TKey> Repositorey<TEntity,TKey>() where TEntity : BaseEntity<TKey>;
    }
}
