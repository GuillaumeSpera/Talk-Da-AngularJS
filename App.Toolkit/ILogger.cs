using System;

namespace App.Toolkit
{
    /// <summary>
    /// Define a Logger service
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a trace message
        /// </summary>
        /// <param name="message">Trace message</param>
        void Trace(string message);

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="message">Debug message</param>
        void Debug(string message);

        /// <summary>
        /// Log a debug message which contains data from an object
        /// </summary>
        /// <param name="obj">Object which contains the data</param>
        void DebugData(object obj);

        /// <summary>
        /// Log an information message
        /// </summary>
        /// <param name="message">Information message</param>
        void Information(string message);

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="message">Warning message</param>
        void Warning(string message);

        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="ex">Exception to log</param>
        void Error(Exception ex);
    }
}
