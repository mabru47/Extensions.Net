namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices
{
    internal interface IServiceE
    {
        IServiceE2 ServiceE2 { get; }
    }

    internal interface IServiceE2
    {
    }

    internal class ServiceE : IServiceE
    {
        public IServiceE2 ServiceE2 { get; }

        public ServiceE(IOptional<IServiceE2> serviceE2)
        {
            ServiceE2 = serviceE2.Service;
        }
    }

    internal class ServiceE2 : IServiceE2
    {
    }
}
