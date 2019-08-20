using Microsoft.AspNetCore.Http;
using Ninject.Web.AspNetCore.Internal;
using System.Threading.Tasks;

namespace Ninject.Web.AspNetCore
{
    public class NinjectMiddleware : IMiddleware
    {
        public const string AspNetCoreNinjectRequestScope = "AspNetCoreNinjectRequestScope";

        public NinjectMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            using (var scope = new RequestScope())
            {
                context.Items[AspNetCoreNinjectRequestScope] = scope;

                await next(context);
            }
        }
    }
}
