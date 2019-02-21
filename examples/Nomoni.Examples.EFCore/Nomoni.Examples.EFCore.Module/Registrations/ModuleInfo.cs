using Nomoni.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nomoni.Examples.Security.Module.Registrations
{
    public class ModuleInfo : IModule
    {
        public string Name => "Example Module";

        public string Author => "Jon Ryan";
    }
}
