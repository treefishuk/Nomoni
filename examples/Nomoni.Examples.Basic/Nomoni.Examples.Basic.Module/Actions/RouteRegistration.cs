using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nomoni.Mvc.Registration;

namespace Nomoni.Examples.Basic.Module.Actions
{
    public class RouteRegistration : IRouteRegistration
    {
        public int Priority => 1000;

        public void Execute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(name: "module", template: "{controller}/{action}/{id?}", defaults: new { controller = "Home", action = "Index" });
        }
    }
}
