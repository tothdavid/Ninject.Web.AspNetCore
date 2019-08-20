using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Ninject.Syntax;
using System.Linq;

namespace Ninject.Web.AspNetCore.Mvc.Internal
{
    public class InjectFiltersControllerModelConvention : IControllerModelConvention
    {
        private readonly IResolutionRoot kernel;

        public InjectFiltersControllerModelConvention(IResolutionRoot kernel)
        {
            this.kernel = kernel;
        }

        public void Apply(ControllerModel controller)
        {
            foreach (var filter in controller.Filters)
            {
                kernel.Inject(filter);
            }
            foreach (var actionFilter in controller.Actions.SelectMany(a => a.Filters))
            {
                kernel.Inject(actionFilter);
            }
        }
    }
}
