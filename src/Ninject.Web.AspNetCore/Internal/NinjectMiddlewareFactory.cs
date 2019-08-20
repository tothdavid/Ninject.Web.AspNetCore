using Microsoft.AspNetCore.Http;
using Ninject.Syntax;
using System;

namespace Ninject.Web.AspNetCore.Internal
{
    public class NinjectMiddlewareFactory : IMiddlewareFactory
    {
        private readonly IResolutionRoot kernel;

        public NinjectMiddlewareFactory(IResolutionRoot kernel)
        {
            this.kernel = kernel;
        }

        public IMiddleware Create(Type middlewareType)
        {
            return (IMiddleware) kernel.Get(middlewareType);
        }

        public void Release(IMiddleware middleware)
        {
        }
    }
}
