using Microsoft.Extensions.DependencyInjection;
using Nomoni.Core.Abstractions;
using Nomoni.Core.Helpers;
using Nomoni.Data.Abstractions;

namespace Nomoni.Data.EntityFramework
{
    public class RepositoryRegistration : IConfigureServicesAction
    {
        public int Priority => 100;

        public void Execute(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAllTypes<IRepository>(ServiceLifetime.Scoped);
        }
    }
}
