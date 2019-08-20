using Microsoft.AspNetCore.Http;

namespace Ninject.Web.AspNetCore.Internal
{
    public interface INinjectHttpContextAccessor
    {
        HttpContext HttpContext { get; }
    }
}