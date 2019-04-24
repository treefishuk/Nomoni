using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nomoni.Core.Abstractions;
using Nomoni.Core.Helpers;
using Nomoni.Data.Abstractions;
using System.Linq;

namespace Nomoni.Data.EntityFramework
{
    public class RepositoryRegistration : IConfigureServicesAction
    {
        readonly ILogger log;

        public RepositoryRegistration(ILogger<RepositoryRegistration> logger)
        {
            log = logger;
        }

        public int Priority => 100;

        public void Execute(IServiceCollection serviceCollection)
        {
            var typesThatImplementIRepository = AssemblyResolution.GetTypes<IRepository>().Where(x => !x.IsInterface && !x.IsAbstract);

            foreach(var type in typesThatImplementIRepository)
            {
                var interfaceToRegister = type.GetInterfaces().Where(x => x.Name.EndsWith("Repository") && !x.Name.Equals("IRepository")).FirstOrDefault();

                if(interfaceToRegister != null)
                {
                    log.LogInformation("Registered: " + interfaceToRegister.Name + " - " + type.Name);

                    serviceCollection.Add(new ServiceDescriptor(interfaceToRegister, type, ServiceLifetime.Scoped));
                }

            }
        }
    }
}
