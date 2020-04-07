namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices
{
    [Implementation(typeof(ServiceA))]
    internal interface IServiceA
    {

    }

    internal class ServiceA : IServiceA
    {
        public ServiceA(IServiceB b, IServiceB b2)
        {

        }
    }
}
