using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrewFourtySeven.Extensions.DependencyInjection
{
    public interface IOptional<T>
    {
        T Service { get; }
    }

    public class Optional<T> : IOptional<T>
    {
        public T Service { get; }

        public Optional(IServiceProvider sp)
        {
            Service = sp.GetService<T>();
        }
    }


    public static class OptionalServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddOptional(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IOptional<>), typeof(Optional<>), ServiceLifetime.Transient));
            return services;
        }

        private static object OptionalFactory(IServiceProvider services)
        {
            return null;
        }
    }
}
