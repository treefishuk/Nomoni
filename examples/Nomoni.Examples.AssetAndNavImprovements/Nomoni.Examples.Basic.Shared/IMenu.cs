using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Examples.Basic.Shared
{
    public interface IMenu
    {
        IEnumerable<MenuItem> MenuItems { get; }
    }
}
