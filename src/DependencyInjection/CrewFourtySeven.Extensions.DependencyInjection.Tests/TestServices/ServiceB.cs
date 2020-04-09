namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices
{
    [Implementation(typeof(ServiceB))]
    internal interface IServiceB
    {

    }

    internal class ServiceB : IServiceB
    {
        public ServiceB(IServiceWithoutImplementation c)
        {

        }
    }
}
