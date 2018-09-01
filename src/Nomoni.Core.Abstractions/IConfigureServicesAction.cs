using Microsoft.Extensions.DependencyInjection;

namespace Nomoni.Core.Abstractions
{
    public interface IConfigureServicesAction
    {
        int Priority { get; }

        void Execute(IServiceCollection serviceCollection);
    }
}
