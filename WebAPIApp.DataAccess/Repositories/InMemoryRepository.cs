﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain;

namespace WebAPIApp.DataAccess.Repositories
{
    public class InMemoryRepository<T>
        : IRepository<T>
        where T : BaseEntity
    {
        private IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
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

        public Task CreateAsync(T entity)
        {
            var data = Data as List<T>;
            data.Add(entity);
            Data = data;
            entity.Id = Guid.NewGuid();

            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            var data = Data as List<T>;
            var fromDb = data.FirstOrDefault(x => x.Id == entity.Id);
            data.Remove(fromDb);
            data.Add(entity);
            Data = data;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            var data = Data as List<T>;
            var fromDb = data.FirstOrDefault(x => x.Id == entity.Id);
            data.Remove(fromDb);
            Data = data;

            return Task.CompletedTask;
        }

        public Task<IEnumerable<T>> GetByCondition(Func<T, bool> predicate)
        {
            var data = Data as List<T>;
            return Task.FromResult(data.Where(predicate).AsEnumerable());
        }
    }
}
