using Microsoft.EntityFrameworkCore;
using Nomoni.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Data.EntityFramework
{
    public static class Extensions
    {
        public static void RegisterEntities(this ModelBuilder builder)
        {
            var entityRegistrations = AssemblyResolution.GetTypes<IEntityRegistration>();

            foreach (var type in entityRegistrations)
            {
                var go = Activator.CreateInstance(type) as IEntityRegistration;

                go.RegisterEntities(builder);
            }
        }

    }
}
