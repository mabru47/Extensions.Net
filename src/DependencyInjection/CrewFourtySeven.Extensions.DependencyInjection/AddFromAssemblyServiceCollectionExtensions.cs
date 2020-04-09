using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
    public static class AddFromAssemblyServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all services with the ServiceAttribute
        /// </summary>
        public static IServiceCollection AddFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var serviceDescriptors = assembly.GetTypes()
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ServiceAttribute)))
                .SelectMany(implementationType =>
                    implementationType.GetCustomAttributes<ServiceAttribute>()
                        .Select(y =>
                            new ServiceDescriptor(y.ServiceType, implementationType, y.Lifetime))
                );

            foreach (var serviceDescriptor in serviceDescriptors)
            {
                services.AddWithDependencies(serviceDescriptor.ServiceType, serviceDescriptor.ImplementationType, serviceDescriptor.Lifetime);
            }

            return services;
        }
    }
}
