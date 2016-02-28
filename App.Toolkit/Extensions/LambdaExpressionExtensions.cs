using System.Reflection;

namespace System.Linq.Expressions
{
    /// <summary>
    /// Méthodes d'extensions sur les lambda
    /// </summary>
    public static class LambdaExpressionExtensions
    {
        /// <summary>
        /// True si l'expression lambda porte sur un champs ou une propriété
        /// </summary>
        /// <param name="lambda">Expression lambda</param>
        /// <returns>True si l'expression lambda porte sur un champs ou une propriété</returns>
        public static bool IsMemberExpression(this LambdaExpression lambda)
        {
            var body = lambda.Body as UnaryExpression;
            return (body != null) ? body.Operand is MemberExpression : lambda.Body is MemberExpression;
        }

        /// <summary>
        /// Renvoie le nom de la propriété définit dans le corps d'une requète lambda
        /// </summary>
        /// <param name="lambda">Expression lambda</param>
        /// <returns>Nom de la propriété</returns>
        /// <exception cref="InvalidCastException">Exception levé si l'expression ne pointe pas sur une propriété ou un champs.</exception>
        public static string GetPropertyInfo(this LambdaExpression lambda)
        {
            var body = lambda.Body as UnaryExpression;
            var member = (body != null)
                 ? (MemberExpression)body.Operand
                 : (MemberExpression)lambda.Body;

            var propertyInfo = (PropertyInfo)member.Member;

            return propertyInfo.Name;
        }
    }
}
