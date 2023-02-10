namespace Pacagroup.Ecommerce.Transversal.Logging
{
    using Microsoft.Extensions.Logging;
    using Pacagroup.Ecommerce.Transversal.Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly ILogger<T> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
