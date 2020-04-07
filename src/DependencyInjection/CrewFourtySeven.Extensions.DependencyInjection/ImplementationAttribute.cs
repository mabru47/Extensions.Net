using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
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
