using System;
using System.Collections.Generic;
using System.Text;

namespace CrewFourtySeven.Extensions.DependencyInjection.Tests.TestServices.Generics
{
    [Implementation(typeof(GenericServiceWithmultipleImplementationsString))]
    [Implementation(typeof(GenericServiceWithMultipleImplementationsInt))]
    interface IGenericServiceWithMultipleImplementations<T>
    {
        void Test(T param);
    }

    class GenericServiceWithmultipleImplementationsString : IGenericServiceWithMultipleImplementations<string>
    {
        public void Test(string param)
        {
            throw new NotImplementedException();
        }
    }

    class GenericServiceWithMultipleImplementationsInt : IGenericServiceWithMultipleImplementations<int>
    {
        public void Test(int param)
        {
            throw new NotImplementedException();
        }
    }
}
