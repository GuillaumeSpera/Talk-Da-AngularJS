using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using App.Toolkit.IoC;

namespace App.Web.Environment.IoC
{
    public class NinjectControllerActivator : IHttpControllerActivator
    {
        /// <summary>
        /// Activateur par défault
        /// </summary>
        private DefaultHttpControllerActivator Activator { get; set; }

        /// <summary>
        /// Crée une nouvelle instance de NinjectControllerActivator
        /// </summary>
        public NinjectControllerActivator()
        {
            Activator = new DefaultHttpControllerActivator();
        }

        /// <summary>
        /// Créer une instance implémentant IHttpController
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = Activator.Create(request, controllerDescriptor, controllerType);

            if (controller != null)
                NinjectHost.Instance.Kernel.Inject(controller);

            request.RegisterForDispose(
                new Release(() =>
                {
                    if (controller != null)
                        NinjectHost.Instance.Kernel.Release(controller);
                }));

            return controller;
        }

        /// <summary>
        /// Class permettant de release l'instance
        /// </summary>
        private class Release : IDisposable
        {
            private Action Action { get; set; }

            public Release(Action release) { Action = release; }

            public void Dispose()
            {
                Action();
            }
        }
    }
}