using Ninject.Extensions.Interception;
using System;

namespace Ninject.Interceptions.Interceptor
{
    public class RepositoryInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.Write(string.Format("The method has just been called with these params - {0}", invocation.Request.Arguments.ToString()));
        }
    }
}
