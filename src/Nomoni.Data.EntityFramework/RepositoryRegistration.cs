using Microsoft.Extensions.DependencyInjection;
using Nomoni.Core.Abstractions;
using Nomoni.Core.Helpers;
using Nomoni.Data.Abstractions;
using System.Linq;

namespace Nomoni.Data.EntityFramework
{
    public class RepositoryRegistration : IConfigureServicesAction
    {
        public int Priority => 100;

        public void Execute(IServiceCollection serviceCollection)
        {
            var typesThatImplementIRepository = AssemblyResolution.GetTypes<IRepository>().Where(x => !x.IsInterface);

            foreach(var type in typesThatImplementIRepository)
            {
                var interfaceToRegister = type.GetInterfaces().Where(x => x.Name.EndsWith("Repository") && !x.Name.Equals("IRepository")).FirstOrDefault();

                serviceCollection.Add(new ServiceDescriptor(interfaceToRegister, type, ServiceLifetime.Scoped));
            }
        }
    }
}
