using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nomoni.Mvc.Extensions
{
    public static class AssemblyResolution
    {
        public static IEnumerable<Assembly> GetAssemblies()
        {
            var path = AppContext.BaseDirectory;

            List<Assembly> allAssemblies = new List<Assembly>();

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                allAssemblies.Add(Assembly.LoadFile(dll));
            }

            return allAssemblies;
        }

        public static IEnumerable<TypeInfo> GetTypes<T>()
        {
            return GetAssemblies().SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
        }
    }
}
