using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain;

namespace WebAPIApp.DataAccess.Repositories
{
    public class NotImplementedRepository<T>
        : IRepository<T>
        where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByCondition(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
