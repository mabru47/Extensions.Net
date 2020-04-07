namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices
{

    [Implementation(typeof(ServiceB))]
    internal interface IServiceB
    {

    }

    internal class ServiceB : IServiceB
    {
        public ServiceB(IServiceA a, IServiceWithoutImplementation c, IServiceB b)
        {

        }
    }
}
