using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain;

namespace WebAPIApp.DataAccess.Repositories
{
    public class InMemoryEmployeesRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryEmployeesRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<T> Add()
        {
            throw new NotImplementedException();
        }

        public Task<T> Update()
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteById()
        {
            throw new NotImplementedException();
        }
    }
}
