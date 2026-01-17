using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency_Injection
{
    public class Dependency
    {
        public Type Type { get; set; }
        public DependencyLifetime Lifetime { get; set; }
        public Dependency(Type type, DependencyLifetime dependencyLifetime)
        {
            Type = type;
            Lifetime = dependencyLifetime;
        }
        public object Implementation { get; set; }
        public bool isImplemented { get; set; } = false;
        
        public void AddImplementation(object implementation)
        {
            Implementation = implementation;
            isImplemented = true;
        }

    }
    public enum DependencyLifetime
    {
        Singleton,
        Transient
    }
}
