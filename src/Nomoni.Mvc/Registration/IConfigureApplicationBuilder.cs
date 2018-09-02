using Microsoft.AspNetCore.Builder;

namespace Nomoni.Mvc.Registration
{
    public  interface IConfigureApplicationBuilder
    {
        int Priority { get; }

        void Execute(IApplicationBuilder applicationBuilder);
    }
}
