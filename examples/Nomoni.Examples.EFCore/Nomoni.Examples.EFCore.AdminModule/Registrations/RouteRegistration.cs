using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nomoni.Mvc.Registration;

namespace Nomoni.Examples.Security.AdminModule.Registrations
{
    public class RouteRegistration : IRouteRegistration
    {
        public int Priority => 2000;

        public void Execute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(name: "admin", template: "admin/{controller}/{action}/{id?}", defaults: new { controller = "Management", action = "Index" });
        }
    }
}
