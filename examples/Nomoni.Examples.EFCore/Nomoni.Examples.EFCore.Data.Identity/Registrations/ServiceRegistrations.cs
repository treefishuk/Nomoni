using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Nomoni.Core.Abstractions;


namespace Nomoni.Examples.EFCore.Data.Identity.Registrations
{
    public class ServiceRegistrations : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //serviceCollection.AddAuthentication(o =>
            //{
            //    o.DefaultScheme = IdentityConstants.ApplicationScheme;
            //    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            //});
        }
    }
}
