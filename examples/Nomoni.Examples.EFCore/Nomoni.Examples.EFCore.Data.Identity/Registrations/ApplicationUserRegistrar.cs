using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nomoni.Data.EntityFramework;
using System;

namespace Nomoni.Examples.EFCore.Data.Identity.Registrations
{
    public class ApplicationUserRegistrar : IEntityRegistration
    {
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
            modelbuilder.Entity<IdentityUser>(etb =>
            {
              etb.HasKey(e => e.Id);
            }
      );
    }
  }
}