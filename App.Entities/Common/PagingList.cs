using System.Collections.Generic;

namespace App.Entities.Common
{
    /// <summary>
    /// Modèle de données paginées
    /// </summary>
    /// <typeparam name="T">Type d'entité remontée</typeparam>
    public class PagingList<T>
    {
        /// <summary>
        /// Liste des résultats
        /// </summary>
        public List<T> Value { get; set; }

        /// <summary>
        /// Nombre de résultat par page
        /// </summary>
        public int ItemPerPage { get; set; }

        /// <summary>
        /// Page actuellement affiché
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Nombre total de résultat sans pagination
        /// </summary>
        public int Count { get; set; }
    }
}
