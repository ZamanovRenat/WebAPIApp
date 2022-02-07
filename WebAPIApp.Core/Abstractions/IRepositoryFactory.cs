using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain;

namespace WebAPIApp.Core.Abstractions
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
