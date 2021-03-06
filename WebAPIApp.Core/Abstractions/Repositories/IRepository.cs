using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIApp.Core.Domain;

namespace WebAPIApp.Core.Abstractions.Repositories
{
    public interface IRepository<T> 
        where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetByCondition(Func<T, bool> predicate);
    }
}
