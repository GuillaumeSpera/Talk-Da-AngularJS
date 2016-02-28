using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Entities.Common;

namespace App.Data
{
    /// <summary>
    /// Définit un repository de base pour gérer les entities
    /// </summary>
    public interface IEntityRepository<T> : IRepository where T : class
    {
        /// <summary>
        /// Ajoute une entité du type T
        /// </summary>
        /// <param name="entity">Entité</param>
        void Add(T entity);

        /// <summary>
        /// Met à jour une entité du type T
        /// </summary>
        /// <param name="entity">Entité</param>
        void Update(T entity);

        /// <summary>
        /// Supprime une entité du type T
        /// </summary>
        /// <param name="entity">Entité</param>
        void Delete(T entity);

        /// <summary>
        /// Supprime un ensemble d'entités correspondant à un type T
        /// </summary>
        /// <param name="where">Condition de recherche des entités</param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// Supprime une entité correspondant à un Identifiant
        /// </summary>
        /// <param name="id">Identifiant</param>
        void DeleteById(int id);

        /// <summary>
        /// Renvoie une entité correspondant à un filtre
        /// </summary>
        /// <param name="where">Filtre, doit représenter une condtion unique sinon une exception sera levé</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>Entité correspondant au filtre</returns>
        T Get(Expression<Func<T, Boolean>> where, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Renvoie l'ensemble des entitiés du type T
        /// </summary>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>L'ensemble des entitiés du type T</returns>
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Renvoie l'ensemble des entitiés du type T
        /// </summary>
        /// <param name="where">Condition de recherche</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>L'ensemble des entitiés du type T</returns>
        IEnumerable<T> GetAll(Expression<Func<T, Boolean>> where, params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// Recherche paginé d'entité du type T
        /// </summary>
        /// <param name="where">Condition de recherche</param>
        /// <param name="paging">Option de pagination</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>Liste paginé d'entité du type T</returns>
        PagingList<T> Search(Expression<Func<T, Boolean>>where, Paging paging, params Expression<Func<T, object>>[] includes);
    }
}
