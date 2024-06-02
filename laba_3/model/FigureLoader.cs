using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace laba_3.Models
{
    public class FigureLoader
    {
        public Assembly LoadedAssembly { get; private set; }
        public List<Type> GeometricFigureTypes { get; private set; }

        public void LoadAssembly(string path)
        {
            LoadedAssembly = Assembly.LoadFrom(path);
            GeometricFigureTypes = LoadedAssembly.GetTypes()
                .Where(t => t.BaseType.FullName != null && !t.IsAbstract)
                .ToList();
        }

        public List<MethodInfo> GetMethods(Type type)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.DeclaringType == type)
                .ToList();
        }
    }
}