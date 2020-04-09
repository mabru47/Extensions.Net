using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
    public static class AddWithDependenciesExtensions
    {
        public static IServiceCollection AddWithDependencies<T>(this IServiceCollection services)
        {
            return services.AddWithDependencies(typeof(T));
        }

        public static IServiceCollection AddWithDependencies(this IServiceCollection services, Type serviceType)
        {
            return AddWithDependenciesInternal(services, serviceType, true);
        }

        public static IServiceCollection AddWithDependencies<TService, TImplementation>(this IServiceCollection services)
        {
            return services.AddWithDependenciesInternal(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient);
        }

        public static IServiceCollection AddWithDependencies<TService, TImplementation>(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            return services.AddWithDependenciesInternal(typeof(TService), typeof(TImplementation), serviceLifetime);
        }

        public static IServiceCollection AddWithDependencies(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType,
            ServiceLifetime serviceLifetime)
        {
            return services.AddWithDependenciesInternal(serviceType, implementationType, serviceLifetime);
        }


        internal static IServiceCollection AddWithDependenciesInternal(this IServiceCollection services, Type serviceType, bool required)
        {
            if (services.ContainsService(serviceType))
            {
                return services;
            }

            var implementationInfos = serviceType
                .GetCustomAttributes<ImplementationAttribute>();

            if (implementationInfos?.Any() != true)
            {
                if (false == required)
                {
                    return services;
                }
                throw new Exception(serviceType.FullName + " has no " + nameof(ImplementationAttribute) + " but is required");
            }

            foreach (var implementationType in implementationInfos)
            {
                services.AddWithDependencies(
                    serviceType,
                    implementationType.ImplementationType,
                    implementationType.Lifetime);
            }
            return services;
        }

        internal static IServiceCollection AddWithDependenciesInternal(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime)
        {
            services.Add(new ServiceDescriptor(serviceType, implementationType, lifetime));

            AddDependencies(services, implementationType);

            return services;
        }

        private static void AddDependencies(IServiceCollection services, Type implementationType)
        {
            var serviceDependencies = implementationType
                .GetConstructors()
                .SingleOrDefault()
                ?.GetParameters()
                ?.Select(x => x.ParameterType);

            if (serviceDependencies?.Any() != true)
            {
                return;
            }

            foreach (var dependencyType in serviceDependencies)
            {
                AddWithDependenciesInternal(services, dependencyType, false);
            }
        }
    }
}
