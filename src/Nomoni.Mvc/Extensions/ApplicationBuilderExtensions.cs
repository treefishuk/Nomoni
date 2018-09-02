using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nomoni.Core.Helpers;
using Nomoni.Mvc.Registration;
using System.Linq;

namespace Nomoni.Mvc.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseNomoni(this IApplicationBuilder appbuilder)
        {
            RegisterApplicationExtensions(appbuilder);

            RegisterRoutes(appbuilder);
        }

        private static void RegisterApplicationExtensions(this IApplicationBuilder appbuilder)
        {
            var extensions = AssemblyResolution.GetInstances<IConfigureApplicationBuilder>();

            foreach (var extention in extensions)
            {
                extention.Execute(appbuilder);
            }
        }

        private static void RegisterRoutes(this IApplicationBuilder appbuilder)
        {

            var extensions = AssemblyResolution.GetInstances<IRouteRegistration>();

            appbuilder.UseMvc(
                   routeBuilder =>
                   {
                       foreach (var extention in extensions.OrderBy(x => x.Priority))
                       {
                           extention.Execute(routeBuilder);
                       }
                   }
                 );

        }
    }
}
