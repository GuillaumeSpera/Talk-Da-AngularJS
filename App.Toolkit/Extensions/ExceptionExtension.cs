using System.Text;

namespace System
{
    /// <summary>
    /// Exception extension
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Get a formatted error message from an Exception
        /// </summary>
        /// <param name="ex">An exception.</param>
        /// <returns>Returns a formated error message of the Exception.</returns>
        public static string GetErrorMessage(this Exception ex)
        {
            return new StringBuilder(ex.Source)
                .Append(" => ")
                .Append(ex.Message)
                .Append(" :\n")
                .Append(ex.StackTrace)
                .ToString();
        }
    }
}
