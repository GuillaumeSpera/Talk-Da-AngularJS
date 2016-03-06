using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using App.Web.Environment.Configuration;

namespace App.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Web API Configuration
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // MVC Route configuration
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}