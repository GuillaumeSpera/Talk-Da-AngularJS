using System;
using System.Linq;
using System.Text;
using App.Toolkit;
using NLog;

namespace App.Web.Environment.Logger
{
    /// <summary>
    /// Logger service
    /// </summary>
    public sealed class Log : ILogger
    {
        /// <summary>
        /// NLog Logger instance
        /// </summary>
        private static readonly NLog.Logger Logger = LogManager.GetLogger("GlobalLogger");

        /// <summary>
        /// Log a trace message
        /// </summary>
        /// <param name="message">Trace message</param>
        public void Trace(string message)
        {
            Logger.Trace(message);
        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="message">Debug message</param>
        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        /// <summary>
        /// Log a debug message which contains data from an object
        /// </summary>
        /// <param name="obj">Object which contains the data</param>
        public void DebugData(object obj)
        {
            Logger.Debug("\n{0}", obj.GetPropertiesData().Aggregate(new StringBuilder(string.Format("{0}", obj.GetType().FullName)), (current, kv) => current.AppendFormat("\n[{0}={1}]", kv.Key, kv.Value)));
        }

        /// <summary>
        /// Log an information message
        /// </summary>
        /// <param name="message">Information message</param>
        public void Information(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="message">Warning message</param>
        public void Warning(string message)
        {
            Logger.Warn(message);
        }

        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public void Error(Exception ex)
        {
            Logger.Error(ex.GetErrorMessage());
        }
    }
}
