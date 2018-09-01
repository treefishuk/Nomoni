using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nomoni.Core.Helpers
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

        public static IEnumerable<T> GetInstances<T>()
        {

            List<T> instances = new List<T>();

            foreach (Type implementation in GetTypes<T>())
            {
                if (!implementation.GetTypeInfo().IsAbstract)
                {
                    T instance = (T)Activator.CreateInstance(implementation);

                    instances.Add(instance);
                }
            }

            return instances;


        }

    }
}
