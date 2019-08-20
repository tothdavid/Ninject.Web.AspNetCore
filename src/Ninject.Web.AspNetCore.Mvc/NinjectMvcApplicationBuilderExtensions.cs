using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Ninject.Web.AspNetCore.Mvc.Internal;

namespace Ninject.Web.AspNetCore.Mvc
{
    public static class NinjectMvcApplicationBuilderExtensions
    {
        public static IMvcCoreBuilder AddNinjectMvc(this IMvcCoreBuilder builder, IKernel kernel)
        {
            var services = builder.Services;
            
            services.AddSingleton<IControllerActivator>(new NinjectControllerActivator(kernel));

            builder.AddMvcOptions(mvcOptions => {
                mvcOptions.Conventions.Add(new InjectFiltersControllerModelConvention(kernel));
            });

            return builder;
        }
    }
}
