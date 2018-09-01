using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Nomoni.Core.Abstractions;
using Nomoni.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static void UseNomoni(this IServiceCollection services)
        {

            services.RegisterAllTypes<IConfigureServicesAction>(ServiceLifetime.Singleton);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            foreach (IConfigureServicesAction action in serviceProvider.GetServices<IConfigureServicesAction>().OrderBy(a => a.Priority))
            {
                action.Execute(services);
                serviceProvider = services.BuildServiceProvider();
            }

            services.ModuleRegistration();

        }

        private static void ModuleRegistration(this IServiceCollection services)
        {
            var assemblies = GetModuleAssemblies();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(new CompositeFileProvider(assemblies.Select(a => new EmbeddedFileProvider(a))));
            });

            services.Configure<StaticFileOptions>(options =>
            {

                var normalStaticFileProvider = new PhysicalFileProvider(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
                var manifestProviders = assemblies.Select(a => new ManifestEmbeddedFileProvider(a, "wwwroot")).ToList();

                List<IFileProvider> prodiders = new List<IFileProvider>();

                foreach(var item in manifestProviders)
                {
                    prodiders.Add(item);
                }

                prodiders.Add(normalStaticFileProvider);

                options.FileProvider = new CompositeFileProvider(prodiders);
            });
        }
    }


}
