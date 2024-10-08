using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Repository.Data.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository.Repositores
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositores;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositores = new Hashtable();
            
        }
        public async Task<int> CompeleteAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repositorey<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
           var type =  typeof(TEntity).Name;
           if(! _repositores.ContainsKey(type))
            {
                var repository =  new GenericRepository<TEntity,TKey>(_context);
                _repositores.Add(type, repository);
            }
            return _repositores[type] as IGenericRepository<TEntity, TKey>;
        }
    }
}
