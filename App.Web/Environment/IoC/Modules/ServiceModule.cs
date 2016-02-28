using App.Service;
using App.Service.Implements;
using Ninject.Modules;

namespace App.Web.Environment.IoC.Modules
{
    /// <summary>
    /// Ninject Module used to inject the business services
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module
        /// </summary>
        public override void Load()
        {
            //Kernel.Bind<IUserService>().To<UserService>().InTransientScope();
        }
    }
}