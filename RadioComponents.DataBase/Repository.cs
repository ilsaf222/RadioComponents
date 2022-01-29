using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioComponents.DataBase
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ComponentContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(ComponentContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity item)
        {
            dbSet.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> items)
        {
            dbSet.AddRange(items);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity item)
        {
            dbSet.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            dbSet.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
