using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Nomoni.Examples.Security.Areas.Identity.IdentityHostingStartup))]
namespace Nomoni.Examples.Security.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}