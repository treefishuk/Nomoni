using Microsoft.AspNetCore.Routing;

namespace Nomoni.Mvc.Registration
{
    public interface IRouteRegistration
    {
         int Priority { get; }
         void Execute(IRouteBuilder routeBuilder);
    }
}
