using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository.Repositores
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task AddASync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Product))
            {
                 return (IEnumerable<TEntity>) await _context.Products.Include( p => p.Brand).Include( p => p.Type).ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey Id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products.Where(p => p.Id == Id as int?).Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync( ) as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
