using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using App.Data.Implements.Context;
using App.Data.Implements.Extensions;
using App.Entities.Common;

namespace App.Data.Implements.Repositories
{
    /// <summary>
    /// Repository de base pour gérer les entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        /// <summary>
        /// Context liée au repository
        /// </summary>
        public object Context
        {
            set { DataContext = (DataContext)value; }
            get { return DataContext; }
        }

        /// <summary>
        /// Context de données
        /// </summary>
        protected DataContext DataContext { get; set; }

        /// <summary>
        /// Ajoute une entité du type T
        /// </summary>
        /// <param name="entity">Entité</param>
        public void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Met à jour une entité du type T
        /// </summary>
        /// <param name="entity">Entité</param>
        public void Update(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Supprime une entité du type T
        /// </summary>
        /// <param name="entity">Entité</param>
        public void Delete(T entity)
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Supprime un ensemble d'entités correspondant à un type T
        /// </summary>
        /// <param name="where">Condition de recherche des entités</param>
        public void Delete(Expression<Func<T, bool>> where)
        {
            if (where == null)
                throw new ArgumentNullException("where");

            var dbSet = DataContext.Set<T>();
            var entities = dbSet.Where(where).AsEnumerable();

            foreach (T obj in entities)
                dbSet.Remove(obj);
        }

        /// <summary>
        /// Supprime une entité correspondant à un Identifiant
        /// </summary>
        /// <param name="id">Identifiant</param>
        public void DeleteById(int id)
        {
            var dbSet = DataContext.Set<T>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Renvoie une entité correspondant à un filtre
        /// </summary>
        /// <param name="where">Filtre, doit représenter une condtion unique sinon une exception sera levé</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>Entité correspondant au filtre</returns>
        public T Get(Expression<Func<T, Boolean>> where, params Expression<Func<T, object>>[] includes)
        {
            if (where == null)
                throw new ArgumentNullException("where");

            return DataContext.Set<T>().Includes(includes).Where(where).FirstOrDefault();
        }

        /// <summary>
        /// Renvoie l'ensemble des entitiés du type T
        /// </summary>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>L'ensemble des entitiés du type T</returns>
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return DataContext.Set<T>().Includes(includes).ToList();
        }

        /// <summary>
        /// Renvoie l'ensemble des entitiés du type T
        /// </summary>
        /// <param name="where">Condition de recherche</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>L'ensemble des entitiés du type T</returns>
        public IEnumerable<T> GetAll(Expression<Func<T, Boolean>> where, params Expression<Func<T, object>>[] includes)
        {
            return DataContext.Set<T>().Includes(includes).Where(where).ToList();
        }

        /// <summary>
        /// Recherche paginé d'entité du type T
        /// </summary>
        /// <param name="paging">Option de pagination</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>Liste paginé d'entité du type T</returns>
        public PagingList<T> Search(Paging paging, params Expression<Func<T, object>>[] includes)
        {
            if (paging == null)
                throw new ArgumentNullException("paging");

            if (paging.SortColumn == null)
                throw new ArgumentNullException("sortColumn");

            var results = DataContext.Set<T>().Includes(includes);
            var totalResult = results.Count();

            results = results.Sort(paging.SortColumn, paging.SortOrder);

            return new PagingList<T>
            {
                Count = totalResult,
                Page = paging.Page,
                ItemPerPage = paging.ItemPerPage,
                Value = results.Skip((paging.Page - 1) * paging.ItemPerPage).Take(paging.ItemPerPage).ToList()
            };
        }

        /// <summary>
        /// Recherche paginé d'entité du type T
        /// </summary>
        /// <param name="where">Condition de recherche</param>
        /// <param name="paging">Option de pagination</param>
        /// <param name="includes">Includes à appliquer</param>
        /// <returns>Liste paginé d'entité du type T</returns>
        public PagingList<T> Search(Expression<Func<T, Boolean>> where, Paging paging, params Expression<Func<T, object>>[] includes)
        {
            if (where == null)
                throw new ArgumentNullException("where");

            if (paging == null)
                throw new ArgumentNullException("paging");

            if (paging.SortColumn == null)
                throw new ArgumentException("SortColumn cannot be null.", "paging");

            var results = DataContext.Set<T>().Includes(includes).Where(where);
            var totalResult = results.Count();

            results = results.Sort(paging.SortColumn, paging.SortOrder);

            return new PagingList<T>
            {
                Count = totalResult,
                Page = paging.Page,
                ItemPerPage = paging.ItemPerPage,
                Value = results.Skip((paging.Page - 1) * paging.ItemPerPage).Take(paging.ItemPerPage).ToList()
            };
        }
    }
}
