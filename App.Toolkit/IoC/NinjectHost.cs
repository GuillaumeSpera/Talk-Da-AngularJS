using System;
using System.Collections.Generic;
using App.Toolkit.IoC.Components;
using Ninject;
using Ninject.Modules;
using Ninject.Selection.Heuristics;

namespace App.Toolkit.IoC
{
    /// <summary>
    /// Host pour l'initialisation des injections de dépendance avec Ninject
    /// </summary>
    public sealed class NinjectHost
    {
        #region Singleton
        /// <summary>
        /// Instance du host Ninject
        /// </summary>
        private static NinjectHost _instance;

        /// <summary>
        /// Objet de synchronisation
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Renvoi l'instance singletonné du host Ninject
        /// </summary>
        public static NinjectHost Instance
        {
            get
            {
                lock (SyncRoot)
                {
                    return _instance ?? (_instance = new NinjectHost());
                }
            }
        }

        /// <summary>
        /// Crée une instance de NinjectHost
        /// </summary>
        private NinjectHost()
        {
            Modules = new List<INinjectModule>();
        }
        #endregion

        /// <summary>
        /// True si le Host est initialisé
        /// </summary>
        private bool _isInitialized;

        /// <summary>
        /// True si le Host est initialisé
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                lock (SyncRoot)
                    return _isInitialized;
            }
            private set
            {
                lock (SyncRoot)
                    _isInitialized = value;
            }
        }

        /// <summary>
        /// Kernel Ninject
        /// </summary>
        private IKernel _kernel;

        /// <summary>
        /// Kernel Ninject
        /// </summary>
        public IKernel Kernel
        {
            get
            {
                lock (SyncRoot)
                    return _kernel;
            }
            private set
            {
                lock (SyncRoot)
                    _kernel = value;
            }
        }

        /// <summary>
        /// Collection de module
        /// </summary>
        private List<INinjectModule> Modules { get; set; }

        /// <summary>
        /// Ajoute un type à inspecter pour l'injection
        /// </summary>
        /// <param name="type">Type à inspecter</param>
        /// <param name="parentType">True si le type est un parent de type à inspecter</param>
        /// <returns>This</returns>
        public NinjectHost AddTypeToInspect(Type type, bool parentType = true)
        {
            NinjectAutoInjectionHeuristic.AddTypeToInspect(type, parentType);
            return this;
        }

        /// <summary>
        /// Ajoute un module
        /// </summary>
        /// <param name="module">Module à ajouter</param>
        /// <returns>Module</returns>
        public NinjectHost AddModule(INinjectModule module)
        {
            Modules.Add(module);
            return this;
        }

        /// <summary>
        /// Initialise le Host
        /// </summary>
        public void Initialize()
        {
            lock (SyncRoot)
            {
                if (_isInitialized) return;

                Kernel = new StandardKernel(Modules.ToArray());
                Kernel.Components.Add<IInjectionHeuristic, NinjectAutoInjectionHeuristic>();

                IsInitialized = true;
            }
        }
    }
}
