using System;
using Microsoft.Extensions.Options;
using WebAPIApp.Core.Abstractions;
using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain;
using WebAPIApp.DataAccess.Repositories;

namespace WebAPIApp.DataAccess.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly bool _isTest;

        public RepositoryFactory(IOptions<DataAccessSettings> options, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _isTest = options.Value.IsTestData;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_isTest)
                return (IRepository<T>)_serviceProvider.GetService(typeof(NotImplementedRepository<T>));

            return (IRepository<T>)_serviceProvider.GetService(typeof(InMemoryRepository<T>));
        }
    }
}
