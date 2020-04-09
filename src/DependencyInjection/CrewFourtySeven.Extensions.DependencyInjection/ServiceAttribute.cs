using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ServiceAttribute : Attribute
    {
        public Type ServiceType { get; }

        public ServiceLifetime Lifetime { get; }

        public ServiceAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            ServiceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
            Lifetime = lifetime;
        }
    }
}
