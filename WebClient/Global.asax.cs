using System;
using System.Web.Routing;
using System.Web.Hosting;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            HostingEnvironment.RegisterVirtualPathProvider(new Hosting.CustomVirtualPathProvider());
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "", // (optional): route name
                "Modules/{module}", //aspx href
                $"~/{Hosting.HostingUtils.VirtualLocation}/{{module}}" //virtual location to redirect to
            );
        }
    }
}