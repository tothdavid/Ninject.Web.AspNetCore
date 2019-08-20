using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ninject.Web.AspNetCore.Internal;
using Ninject.Web.Common;

namespace Ninject.Web.AspNetCore
{
    public static class NinjectApplicationBuilderExtensions
    {
        public const string NinjectAspNetCoreBootstrapperKey = "NinjectAspNetCoreBootstrapper";

        public static IServiceCollection AddNinject(this IServiceCollection services, IKernel kernel)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<IMiddlewareFactory>(new NinjectMiddlewareFactory(kernel));

            return services;
        }

        public static IApplicationBuilder UseNinject(this IApplicationBuilder app, IKernel kernel, IApplicationLifetime applicationLifetime)
        {
            kernel.Bind<INinjectHttpContextAccessor>().ToMethod(_ => 
                new NinjectHttpContextAccessor(app.ApplicationServices.GetService<IHttpContextAccessor>())
            );
            kernel.Bind<IRequestScopeAccessor>().To<RequestScopeAccessor>();
            kernel.Components.Add<INinjectHttpApplicationPlugin, AspNetCoreNinjectHttpApplicationPlugin>();
            
            var bootstrapper = new Bootstrapper();
            app.Properties.Add(NinjectAspNetCoreBootstrapperKey, bootstrapper);

            bootstrapper.Initialize(() => kernel);
            applicationLifetime.ApplicationStopped.Register(() => bootstrapper.ShutDown());
            
            return app.UseMiddleware<NinjectMiddleware>();
        }
    }
}
