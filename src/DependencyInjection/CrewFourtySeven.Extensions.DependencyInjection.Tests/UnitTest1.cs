using CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace CrewFourtySeven.Extensions.DependencyInjection.Tests
{
    public class Tests
    {
        public Tests()
        {

        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddWithDependenciesTest()
        {
            var serviceCollection = new ServiceCollection()
                .AddWithDependencies<IServiceA>();

            Assert.AreEqual(1, serviceCollection.Count(x => x.ServiceType == typeof(IServiceA)));
            Assert.AreEqual(1, serviceCollection.Count(x => x.ServiceType == typeof(IServiceB)));
            Assert.False(serviceCollection.Any(x => x.ServiceType == typeof(IServiceWithoutImplementation)));
        }

        [Test]
        public void AddFromAssemblyTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddFromAssembly(Assembly.GetExecutingAssembly())
                .BuildServiceProvider();

            Assert.AreEqual(1, serviceProvider.GetServices<IServiceC>().Count());
            Assert.AreEqual(2, serviceProvider.GetServices<IServiceD>().Count());
            Assert.AreEqual(0, serviceProvider.GetServices<IServiceA>().Count());
            Assert.AreEqual(0, serviceProvider.GetServices<IServiceB>().Count());
        }

        [Test]
        public void NotRequiredAttributeTests()
        {
            var serviceCollection = new ServiceCollection()
                .AddOptional()
                .AddTransient<IServiceE, ServiceE>();

            var serviceProvider0 = serviceCollection.BuildServiceProvider();
            Assert.Null(serviceProvider0.GetRequiredService<IServiceE>().ServiceE2);

            serviceCollection.AddTransient<IServiceE2, ServiceE2>();
            var serviceProvider1 = serviceCollection.BuildServiceProvider();
            Assert.NotNull(serviceProvider1.GetRequiredService<IServiceE>().ServiceE2);

        }
    }
}