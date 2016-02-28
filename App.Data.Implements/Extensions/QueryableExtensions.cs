using System.Linq;
using System.Linq.Expressions;

namespace System.Data.Entity
{
    /// <summary>
    /// Méthode d'extensions pour les Types IQueryable
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Include une collection d'expression
        /// </summary>
        /// <param name="query">DbSet étendu</param>
        /// <param name="includes">Expressions à inclure</param>
        /// <returns>DbSet étendu</returns>
        public static IQueryable<T> Includes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }
    }
}
