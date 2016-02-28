using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject.Components;
using Ninject.Selection.Heuristics;

namespace App.Toolkit.IoC.Components
{
    /// <summary>
    /// Composant Ninject permettant de réaliser les injections en automatique.
    /// (attribut Inject inutile, permet de casser l'adhérence à Ninject dans les couches bas niveau)
    /// </summary>
    internal class NinjectAutoInjectionHeuristic : NinjectComponent, IInjectionHeuristic
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static NinjectAutoInjectionHeuristic()
        {
            PropertyTypeToInspect = new List<Type>();
        }

        /// <summary>
        /// Liste des types de propriété pouvant être injecter automatiquement via Ninject.
        /// </summary>
        private static List<Type> PropertyTypeToInspect { get; set; }

        /// <summary>
        /// Ajoute l'ensemble des types interface contenu dans l'AppDomain et étant du type ou enfant du type à la collection des types à inspecter par l'Heuristique
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentType"></param>
        internal static void AddTypeToInspect(Type type, bool parentType)
        {
            if (!type.IsInterface)
                throw new InvalidOperationException("Type to inspect must be an Interface");

            if (parentType)
            {
                PropertyTypeToInspect.AddRange(
                    (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     from t in assembly.GetTypes()
                     where t.IsInterface && type.IsAssignableFrom(t) && t != type && !PropertyTypeToInspect.Contains(t)
                     select t).ToList()
                );
            }
            else
            {
                if (!PropertyTypeToInspect.Contains(type))
                    PropertyTypeToInspect.Add(type);
            }
        }

        /// <summary>
        /// True si le membre inspecté est un membre a injecté.
        /// </summary>
        /// <param name="member">Membre à inspecter</param>
        /// <returns>True si le member inspecté est un membre a injecté.</returns>
        public bool ShouldInject(MemberInfo member)
        {
            var propertyInfo = member as PropertyInfo;

            if (member == null || propertyInfo == null)
                return false;

            //todo Ameliorer la comparaison de type  
            return propertyInfo.CanWrite && PropertyTypeToInspect.Any(x => x.Name == propertyInfo.PropertyType.Name);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            PropertyTypeToInspect.Clear();
            base.Dispose(disposing);
        }
    }
}