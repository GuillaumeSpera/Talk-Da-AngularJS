using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace App.Entities.Common
{
    /// <summary>
    /// Définit un résultat
    /// </summary>
    /// <typeparam name="T">Type encapsuler dans l'objet Result</typeparam>
    public class Result<T>
    {
        #region Properties

        /// <summary>
        /// Valeur du résultat
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// True si le résultat contient une valeur
        /// </summary>
        public bool HasValue { get { return Value != null; } }

        /// <summary>
        /// Le code HTTP de retour
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; private set; }

        /// <summary>
        /// Messages des erreurs
        /// </summary>
        public IEnumerable<string> ErrorMessages { get; private set; }

        /// <summary>
        /// True si le résultat est en erreur
        /// </summary>
        public bool HasError { get { return ErrorMessages != null && ErrorMessages.Any(); } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur avec une liste d'erreur
        /// </summary>
        /// <param name="value">Valeur du résultat</param>
        /// <param name="httpStatusCode">Code HTTP de retour</param>
        public Result(T value, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Value = value;
            HttpStatusCode = httpStatusCode;
        }

        /// <summary>
        /// Constructeur avec une liste d'erreur
        /// </summary>
        /// <param name="value">Valeur du résultat</param>
        /// <param name="httpStatusCode">Code HTTP de retour</param>
        /// <param name="message">Message de l'erreur</param>
        public Result(T value, HttpStatusCode httpStatusCode, string message)
        {
            Value = value;
            HttpStatusCode = httpStatusCode;
            if (!string.IsNullOrEmpty(message))
            {
                ErrorMessages = new string[] { message };
            }
        }

        /// <summary>
        /// Constructeur avec une liste d'erreur
        /// </summary>
        /// <param name="value">Valeur du résultat</param>
        /// <param name="httpStatusCode">Code HTTP de retour</param>
        /// <param name="messages">Messages d'erreurs</param>
        public Result(T value, HttpStatusCode httpStatusCode, IEnumerable<string> messages)
        {
            Value = value;
            HttpStatusCode = httpStatusCode;
            ErrorMessages = messages;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Cast implicit
        /// </summary>
        /// <param name="result">Resultat à caster</param>
        /// <returns>Valeur du resultat</returns>
        public static implicit operator T(Result<T> result)
        {
            return result == null ? default(T) : result.Value;
        }

        #endregion
    }
}
