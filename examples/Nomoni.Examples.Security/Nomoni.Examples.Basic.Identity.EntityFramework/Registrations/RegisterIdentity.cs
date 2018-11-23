using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Nomoni.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Example.Basic.Identity.EntityFramework.Registrations
{
    public class RegisterIdentity : IConfigureServicesAction
    {
        public int Priority => 10;

        public void Execute(IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
              .AddDefaultTokenProviders();
        }
    }
}
