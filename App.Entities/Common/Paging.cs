using System.Collections.Generic;

namespace App.Entities.Common
{
    /// <summary>
    /// Paramètre de pagination
    /// </summary>
    public class Paging
    {
        /// <summary>
        /// Numéro de la page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Nombre de résultat par page
        /// </summary>
        public int ItemPerPage { get; set; }

        /// <summary>
        /// Champ de tri
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Direction du tri
        /// </summary>
        public bool SortOrder { get; set; }
        /// <summary>
        ///  champ de recherche
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Sort> SortList { get; set; }

    }

    public class Sort
    {
        /// <summary>
        /// Champ de tri
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Direction du tri
        /// </summary>
        public bool SortOrder { get; set; }
    }
}
