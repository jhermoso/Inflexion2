//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging.NetLog
{
    using System;

    public class NLogLogger : Inflexion2.Logging.LoggerBase
    {
        /// <summary>NLog logger that this adapter wraps</summary>
        private readonly NLog.Logger logger;

        /// <summary>Used to exclude Inflexion2.Logging from call site information</summary>
        private readonly static Type declaringType = typeof(Inflexion2.Logging.LoggerBase);

        /// <summary>
        /// Wrap an instance of an NLog logger
        /// </summary>
        /// <param name="logger">NLog logger to wrap</param>
        protected internal NLogLogger(NLog.Logger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Log to the wrapped NLog logger
        /// </summary>
        public override void Log(Inflexion2.Logging.LogEntry entry)
        {
            var nlogLogLevel = MapLogLevel(entry.LogLevel);

            var nlogEntry = new NLog.LogEventInfo()
            {
                Level = nlogLogLevel,
                TimeStamp = entry.Timestamp,
                Message = entry.Message,
                Exception = entry.Exception
            };

            // Add Windows Event Log ID, if present in source log entry
            if (entry.EventId.HasValue)
            {
                nlogEntry.Properties.Add("EventID", entry.EventId);
            }

            this.logger.Log(declaringType, nlogEntry);
        }

        /// <summary>
        /// Maps an Inflexion2.Logging log level to an NLog log level
        /// </summary>
        /// <remarks>
        /// NLog has log levels that correspond to the Inflexion2.Logging log levels, so 
        /// this is a 1:1 mapping
        /// </remarks>
        /// <param name="logLevel">Inflexion2.Logging log level to be mapped</param>
        /// <returns>NLog log level</returns>
        private NLog.LogLevel MapLogLevel(Inflexion2.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Inflexion2.Logging.LogLevel.Fatal:
                    return NLog.LogLevel.Fatal;

                case Inflexion2.Logging.LogLevel.Error:
                    return NLog.LogLevel.Error;

                case Inflexion2.Logging.LogLevel.Warn:
                    return NLog.LogLevel.Warn;

                case Inflexion2.Logging.LogLevel.Info:
                    return NLog.LogLevel.Info;

                case Inflexion2.Logging.LogLevel.Debug:
                    return NLog.LogLevel.Debug;

                case Inflexion2.Logging.LogLevel.Trace:
                    return NLog.LogLevel.Trace;

                default:
                    return NLog.LogLevel.Info;
            }
        }
    }
}
