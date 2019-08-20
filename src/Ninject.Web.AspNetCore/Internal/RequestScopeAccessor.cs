namespace Ninject.Web.AspNetCore.Internal
{
    internal class RequestScopeAccessor : IRequestScopeAccessor
    {
        private readonly INinjectHttpContextAccessor httpContextAccessor;

        public RequestScopeAccessor(INinjectHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public object GetRequestScope()
        {
            object scope = null;
            httpContextAccessor.HttpContext?.Items.TryGetValue(NinjectMiddleware.AspNetCoreNinjectRequestScope, out scope);

            return scope;
        }
    }
}