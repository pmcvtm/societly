using System.Web.Mvc;
using System.Web.Routing;
using StructureMap.Web.Pipeline;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_EndRequest()
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}
