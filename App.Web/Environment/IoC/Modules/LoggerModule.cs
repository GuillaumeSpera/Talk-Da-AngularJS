using App.Toolkit;
using App.Web.Environment.Logger;
using Ninject.Modules;

namespace App.Web.Environment.IoC.Modules
{
    /// <summary>
    /// Ninject Module used to inject the logger
    /// </summary>
    public class LoggerModule : NinjectModule
    {
        /// <summary>
        /// Loads the module
        /// </summary>
        public override void Load()
        {
            Kernel.Bind<ILogger>().To<Log>();
        }
    }
}