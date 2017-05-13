//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{

    // TODO: Implement ILogger instead, to make it truely 'noop'
    /// <summary>
    /// Default <see cref="ILogger"/> implementation that silently drops all log entries
    /// 
    /// This logger is used if configuration is incomplete or invalid
    /// </summary>
    public class NullLogger : LoggerBase
    {
        /// <summary>
        /// Does nothing
        /// </summary>
        /// <param name="entry">Entry to drop</param>
        public override void Log(LogEntry entry)
        {
            // Do nothing
        }
    }
}
