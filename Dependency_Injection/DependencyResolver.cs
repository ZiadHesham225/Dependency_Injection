using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Dependency_Injection
{
    public class DependencyResolver
    {
        private DependencyContainer _dependencyContainer;
        public DependencyResolver(DependencyContainer dc)
        {
            _dependencyContainer = dc;
        }
        public T getService<T>()
        {
            return (T)getService(typeof(T));
        }
        public object getService(Type type)
        {
            var dependency = _dependencyContainer.GetDependency(type);
            var constructor = dependency.Type.GetConstructors().Single();
            var parameters = constructor.GetParameters().ToArray();
            if(parameters.Length > 0)
            {
                var parameterImplementations = new Object[parameters.Length];
                for(int i = 0; i < parameters.Length; i++)
                {
                    parameterImplementations[i] = getService(parameters[i].ParameterType);
                }
                return createImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations));
            }
            return createImplementation(dependency, t => Activator.CreateInstance(t));
        }
        public Object createImplementation(Dependency dependency, Func<Type, Object> factory)
        {
            if (dependency.isImplemented)
            {
                return dependency.Implementation;
            }
            var implementation = factory(dependency.Type);
            if(dependency.Lifetime == DependencyLifetime.Singleton)
            {
                dependency.AddImplementation(implementation);
            }
            return implementation;
        }
    }
}
