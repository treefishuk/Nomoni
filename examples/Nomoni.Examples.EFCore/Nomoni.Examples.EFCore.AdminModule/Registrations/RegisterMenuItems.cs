using Nomoni.Examples.Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nomoni.Examples.Security.AdminModule.Registrations
{
    public class RegisterMenuItems : IMenu
    {
        public IEnumerable<MenuItem> MenuItems
        {
            get
            {
                return new MenuItem[]
                {
                    new MenuItem("Management", 200, "/admin/management")
                };
            }
        }
    }
}
