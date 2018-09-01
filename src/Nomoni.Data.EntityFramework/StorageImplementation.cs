using Nomoni.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Nomoni.Data.EntityFramework
{
    public class StorageImplementation : IStorage
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly DbContext _dbContext;

        public StorageImplementation(IServiceProvider serviceProvider, DbContext dbContext)
        {
            _serviceProvider = serviceProvider;
            _dbContext = dbContext;
        }

        public T GetRepository<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
