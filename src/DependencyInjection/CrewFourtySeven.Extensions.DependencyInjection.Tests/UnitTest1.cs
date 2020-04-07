using CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;

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
        public void Test1()
        {
            var serviceCollection = new ServiceCollection().AddWithDependencies<IServiceA>();
            Assert.AreEqual(1, serviceCollection.Count(x => x.ServiceType == typeof(IServiceA)));
            Assert.AreEqual(1, serviceCollection.Count(x => x.ServiceType == typeof(IServiceB)));
            Assert.False(serviceCollection.Any(x => x.ServiceType == typeof(IServiceWithoutImplementation)));
        }

        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}