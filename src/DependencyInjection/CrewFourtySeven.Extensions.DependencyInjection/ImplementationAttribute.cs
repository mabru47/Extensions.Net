using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
    public class ImplementationAttribute : Attribute
    {
        public Type ImplementationType { get; }

        public ServiceLifetime Lifetime { get; }

        public ImplementationAttribute(Type implementationType, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }
    }
}
