using App.Data;
using App.Data.Implements.Repositories;
using Ninject.Modules;

namespace App.Web.Environment.IoC.Modules
{
    /// <summary>
    /// Ninject Module used to inject the repositories
    /// </summary>
    public class DataModule : NinjectModule
    {
        /// <summary>
        /// Loads the module
        /// </summary>
        public override void Load()
        {
            Kernel.Bind(typeof(IEntityRepository<>)).To(typeof(EntityRepository<>));
            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}