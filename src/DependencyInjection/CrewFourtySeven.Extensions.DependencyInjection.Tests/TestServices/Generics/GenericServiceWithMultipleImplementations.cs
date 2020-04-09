using System;

namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices.Generics
{
    [Implementation(typeof(GenericServiceWithmultipleImplementationsString))]
    [Implementation(typeof(GenericServiceWithMultipleImplementationsInt))]
    internal interface IGenericServiceWithMultipleImplementations<T>
    {
        void Test(T param);
    }

    internal class GenericServiceWithmultipleImplementationsString : IGenericServiceWithMultipleImplementations<string>
    {
        public void Test(string param)
        {
            throw new NotImplementedException();
        }
    }

    internal class GenericServiceWithMultipleImplementationsInt : IGenericServiceWithMultipleImplementations<int>
    {
        public void Test(int param)
        {
            throw new NotImplementedException();
        }
    }
}
