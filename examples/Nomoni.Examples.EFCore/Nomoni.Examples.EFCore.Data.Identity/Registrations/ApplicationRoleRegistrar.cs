using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nomoni.Data.EntityFramework;

namespace Nomoni.Examples.EFCore.Data.Identity.Registrations
{
    public class ApplicationRoleRegistrar : IEntityRegistration
    {
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
            modelbuilder.Entity<IdentityRole>(etb =>
            {
              etb.HasKey(e => e.Id);
            }
      );
    }
  }
}