using System.Web.Mvc;
using System.Web.Routing;

namespace App.Web.Environment.Configuration
{
    /// <summary>
    /// Route configuration for Asp.net MVC
    /// </summary>
    public class RouteConfig
    {

        /// <summary>
        /// Routes registration
        /// </summary>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // No matter which url is requested, the Index action will be called
            routes.MapRoute(
                name: "Default SPA route",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
