using Microsoft.Extensions.DependencyInjection;
using Nomoni.Core.Abstractions;
using Nomoni.Data.Abstractions;

namespace Nomoni.Data.EntityFramework
{
    public static class StorageRegistration
    {
        public static void UseEFCoreStorage(this IServiceCollection services)
        {
            services.AddScoped<IStorage, StorageImplementation>();

        }

    }
}
