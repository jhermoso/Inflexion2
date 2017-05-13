//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// Container for log data that can be consumed by any <see cref="ILogger"/>
    /// </summary>
    public class LogEntry
    {
        /// <summary>Defaults to <see cref="Inflexion2.Logging.LogLevel.Info"/></summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// log time stamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// log message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// log exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>Windows Event Log event identifier</summary>
        public int? EventId { get; set; }

        public LogEntry()
        {
            this.LogLevel = LogLevel.Info;
            this.Timestamp = DateTime.UtcNow;
            this.Message = String.Empty;
            this.Exception = null;
            this.EventId = null;
        }
    }
}
