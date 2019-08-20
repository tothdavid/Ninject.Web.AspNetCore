using Microsoft.AspNetCore.Http;

namespace Ninject.Web.AspNetCore.Internal
{
    public class NinjectHttpContextAccessor : INinjectHttpContextAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpContext HttpContext => httpContextAccessor.HttpContext;

        public NinjectHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}