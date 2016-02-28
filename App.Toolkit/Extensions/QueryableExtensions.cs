using System.Linq.Expressions;

namespace System.Linq
{
    /// <summary>
    /// Méthode d'extensions pour les Types IQueryable
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Trie une requête
        /// </summary>
        /// <param name="queryable">Requête</param>
        /// <param name="sortProperty">Propriété sur laquelle faire le trie</param>
        /// <param name="sortAscending">True si trie ascendant</param>
        /// <returns>Requête contenant la gestion du trie</returns>
        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, string sortProperty, bool sortAscending)
        {
            var sortMethodName = sortAscending ? "OrderBy" : "OrderByDescending";

            var type = queryable.ElementType;
            var property = type.GetProperty(sortProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderExpression = Expression.Lambda(propertyAccess, parameter);
            return (IQueryable<T>)queryable.Provider.CreateQuery(Expression.Call(typeof(Queryable), sortMethodName, new[] { type, property.PropertyType }, queryable.Expression, Expression.Quote(orderExpression)));
        }

        /// <summary>
        /// Trie une requête via une expression lambda
        /// </summary>
        /// <param name="queryable">Requête</param>
        /// <param name="sortPropertyExp">Expression définissant la propriété Propriété sur laquelle faire le trie</param>
        /// <param name="sortAscending">True si trie ascendant</param>
        /// <returns></returns>
        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, Expression<Func<T, object>> sortPropertyExp,
                                            bool sortAscending)
        {
            if (!sortPropertyExp.IsMemberExpression())
                throw new ArgumentException("sortPropertyExp");

            var propertyName = sortPropertyExp.GetPropertyInfo();
            // var propertyName = sortPropertyExp.GetPropertyNameFromPropertyExpression();
            return queryable.Sort(propertyName, sortAscending);
        }
    }
}
