namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices
{
    internal interface IServiceD
    {
    }

    [Service(typeof(IServiceD))]
    internal class ServiceD : IServiceD
    {
    }

    [Service(typeof(IServiceD))]
    internal class ServiceD2 : IServiceD
    {
        public ServiceD2(IServiceB b)
        {

        }
    }
}
