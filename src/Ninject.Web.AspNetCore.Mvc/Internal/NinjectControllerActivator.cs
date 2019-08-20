using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Ninject.Syntax;

namespace Ninject.Web.AspNetCore.Mvc.Internal
{
    public sealed class NinjectControllerActivator : IControllerActivator
    {
        private readonly IResolutionRoot kernel;

        public NinjectControllerActivator(IResolutionRoot kernel)
        {
            this.kernel = kernel;
        }


        public object Create(ControllerContext context)
        {
            var type = context.ActionDescriptor.ControllerTypeInfo.AsType();

            return kernel.Get(type);
        }

        public void Release(ControllerContext context, object controller)
        {
        }
    }
}
