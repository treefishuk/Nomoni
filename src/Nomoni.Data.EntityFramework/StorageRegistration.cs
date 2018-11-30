using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nomoni.Core.Abstractions;
using Nomoni.Data.Abstractions;

namespace Nomoni.Data.EntityFramework
{
    public class StorageRegistration : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorage, StorageImplementation>();
        }
    }
}
