using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Nomoni.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nomoni.Mvc.Extensions
{
    public static class ServicesExtensions
    {
        private static IEnumerable<Assembly> GetModuleAssemblies()
        {
            return AssemblyResolution.GetTypes<IModule>().Select(s => s.Assembly).Distinct();
        }

        public static void RegisterAllTypes<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var types = AssemblyResolution.GetTypes<T>();

            foreach (var type in types)
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
            }
        }

        public static void UseModules(this IServiceCollection services)
        {
            services.ModuleRegistration();

            services.RegisterAllTypes<IConfigureServicesAction>(ServiceLifetime.Singleton);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            foreach (IConfigureServicesAction action in serviceProvider.GetServices<IConfigureServicesAction>().OrderBy(a => a.Priority))
            {
                action.Execute(services);
                serviceProvider = services.BuildServiceProvider();
            }
        }

        public static void ModuleRegistration(this IServiceCollection services)
        {

            var assemblies = GetModuleAssemblies();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(new CompositeFileProvider(assemblies.Select(a => new EmbeddedFileProvider(a))));
            });

            services.Configure<StaticFileOptions>(options =>
            {
                options.FileProvider = new CompositeFileProvider(assemblies.Select(a => new ManifestEmbeddedFileProvider(a, "wwwroot")));
            });

        }

    }



}
