namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices
{
    internal interface IServiceC
    {

    }

    [Service(typeof(IServiceC))]
    internal class ServiceC : IServiceC
    {
        public ServiceC(IServiceD serviceD)
        {

        }
    }
}
