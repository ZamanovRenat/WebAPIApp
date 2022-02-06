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
        Task<T> Add();
        Task<T> Update();
        Task<T> Delete();
        Task<T> DeleteById();
    }
}
