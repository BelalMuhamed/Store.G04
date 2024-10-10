using Store.G04.Core.Entities;
using Store.G04.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repositories.Contract
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetAsync(TKey key);
        public Task<IEnumerable<TEntity>> GetAllWithSpecificAsync(ISpecifications<TEntity, TKey> spec);
        public Task<TEntity> GetWithSpecificAsync(ISpecifications<TEntity, TKey> spec);
        public Task AddASync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<int> GetCountAsync(ISpecifications<TEntity,TKey> spec);
    }
}
