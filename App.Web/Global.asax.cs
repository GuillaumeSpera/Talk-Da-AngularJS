using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using App.Data;
using App.Service;
using App.Toolkit.IoC;
using App.Web.Environment.Configuration;
using App.Web.Environment.IoC;
using App.Web.Environment.IoC.Modules;

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

            // Ninject reference modules, register types to inspect and initialize call
            NinjectHost.Instance
                .AddModule(new DataModule())
                .AddTypeToInspect(typeof(IRepository))
                .AddTypeToInspect(typeof(IUnitOfWork), false)
                .AddModule(new ServiceModule())
                .AddTypeToInspect(typeof(IService))
                .Initialize();

            // Register a new HttpControllerActivator to let Ninject handle the injection
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new NinjectControllerActivator());
        }
    }
}