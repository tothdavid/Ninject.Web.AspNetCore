using Ninject.Activation;
using Ninject.Components;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace Ninject.Web.AspNetCore.Internal
{
    public class AspNetCoreNinjectHttpApplicationPlugin : NinjectComponent, INinjectHttpApplicationPlugin
    {
        private readonly IResolutionRoot kernel;

        public AspNetCoreNinjectHttpApplicationPlugin(IResolutionRoot kernel)
        {
            this.kernel = kernel;
        }

        public object GetRequestScope(IContext context) =>
            kernel.Get<IRequestScopeAccessor>().GetRequestScope();

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}
