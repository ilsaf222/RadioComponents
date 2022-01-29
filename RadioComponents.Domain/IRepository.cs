using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioComponents.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity item);
        Task AddRangeAsync(IEnumerable<TEntity> items);
        Task RemoveAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task SaveChangesAsync();
    }
}
