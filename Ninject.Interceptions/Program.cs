using System;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Interceptions.Interceptor;
using Ninject.Interceptions.Repository;

namespace Ninject.Interceptions
{
    class Program
    {
        static void Main()
        {
            var kernel = CreateBindings();
            var entryPoint = new ApplicationEntryPoint(kernel.Get<IRepository>());
            //Breakpoint on the RepositoryInterceptor and see the arguments for both.
            entryPoint.GetByIdFromRepo();
            entryPoint.GetAllBetweenDatesFromRepo();
        }

        private static StandardKernel CreateBindings()
        {
            // Enable the extension loading in the kernel
            var kernel = new StandardKernel(new NinjectSettings() {LoadExtensions = true});

            // Note how we're binding the interceptors to the concrete type before we bind the interface
            // to it. We're going to intercept after we call the GetById method on the repository.
            // Dynamic proxing means we don't have to specify the arguments when binding, its just here
            // to describe the method signature
            kernel.InterceptAfter<Repository.Repository>(foo => foo.GetById(0),
                                                         invocation =>
                                                         new RepositoryInterceptor()
                                                         .Intercept(invocation));

            // We're going to intercept after we call the GetAllBetween method on the repository
            kernel.InterceptBefore<Repository.Repository>(foo => foo.GetAllBetween(new DateTime(), new DateTime()),
                                                         invocation =>
                                                         new RepositoryInterceptor()
                                                         .Intercept(invocation));
            //Now we bind the concrete class to the repository
            kernel.Bind<IRepository>().To<Repository.Repository>();
            return kernel;
        }
    }
}
