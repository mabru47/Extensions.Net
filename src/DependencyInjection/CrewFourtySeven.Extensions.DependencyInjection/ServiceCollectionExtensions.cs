using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static bool ContainsService<T>(this IServiceCollection services)
        {
            return ContainsService(services, typeof(T));
        }

        public static bool ContainsService(this IServiceCollection services, Type serviceType)
        {
            return services
                .Any(x => x.ServiceType == serviceType || serviceType.IsGenericType && x.ServiceType == serviceType.GetGenericTypeDefinition());
        }

        public static bool ContainsServiceWithImplementation(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            return services
                .Where(x => x.ServiceType == serviceType || serviceType.IsGenericType && x.ServiceType == serviceType.GetGenericTypeDefinition())
                .Any(x => x.ImplementationType == implementationType);
        }
    }
}
