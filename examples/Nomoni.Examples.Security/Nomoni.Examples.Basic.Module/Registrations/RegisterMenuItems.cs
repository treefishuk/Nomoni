using Nomoni.Examples.Basic.Shared;
using System.Collections.Generic;

namespace Nomoni.Examples.Basic.Module.Registrations
{
    public class RegisterMenuItems : IMenu
    {
        public IEnumerable<MenuItem> MenuItems
        {
            get
            {
                return new MenuItem[]
                {
                            new MenuItem("Home", 100, "/"),
                            new MenuItem("About", 120, "/home/about"),
                            new MenuItem("Contact", 130, "/home/contact")
                };
            }
        }
    }
}
