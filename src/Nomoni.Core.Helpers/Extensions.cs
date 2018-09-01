using Microsoft.Extensions.DependencyInjection;

namespace Nomoni.Core.Helpers
{
    public static class Extensions
    {
        public static void RegisterAllTypes<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var types = AssemblyResolution.GetTypes<T>();

            foreach (var type in types)
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
            }
        }
    }
}
