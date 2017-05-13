//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// Interface for adapters that wrap logger implementations
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// log with a LogEntry
        /// </summary>
        /// <param name="entry"></param>
        void Log(LogEntry entry);

        #region Trace

        /// <summary>
        /// trace with an object
        /// </summary>
        /// <param name="message"></param>
        void Trace(object message);

        /// <summary>
        /// trace with string format template and variable string args
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Trace(string format, params object[] args);

        /// <summary>
        /// trace with object message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Trace(object message, Exception exception);

        /// <summary>
        /// trace with string format template, exception and variable string args
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Trace(string format, Exception exception, params object[] args);

        /// <summary>
        /// trace event with message
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        void Trace(int eventId, object message);

        /// <summary>
        /// trace event with string format template and variable string args
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Trace(int eventId, string format, params object[] args);

        /// <summary>
        /// trace event with and exception
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Trace(int eventId, object message, Exception exception);

        /// <summary>
        /// trace event, and exception with string format template and variable string args
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Trace(int eventId, string format, Exception exception, params object[] args);
        #endregion

        #region Debug
        /// <summary>
        /// Log debug  with object 
        /// </summary>
        /// <param name="message"></param>
        void Debug(object message);

        /// <summary>
        /// Log debug  with string format template and variable string args
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Log debug  exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// Log debug  exception with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Debug(string format, Exception exception, params object[] args);

        /// <summary>
        /// Log debug  event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        void Debug(int eventId, object message);

        /// <summary>
        /// Debug event with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Debug(int eventId, string format, params object[] args);

        /// <summary>
        /// Log debug  event and exception.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(int eventId, object message, Exception exception);

        /// <summary>
        /// Log debug event and exception with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Debug(int eventId, string format, Exception exception, params object[] args);
        #endregion

        #region Info
        /// <summary>
        /// Log info event and exception with string format template and variable string args.
        /// </summary>
        /// <param name="message"></param>
        void Info(object message);

        /// <summary>
        /// Log info with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Log info exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(object message, Exception exception);

        /// <summary>
        /// Log info exception with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Info(string format, Exception exception, params object[] args);

        /// <summary>
        /// Log info event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        void Info(int eventId, object message);

        /// <summary>
        /// Log info event and exception with string format template and variable string args
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Info(int eventId, string format, params object[] args);

        /// <summary>
        /// Log info event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(int eventId, object message, Exception exception);

        /// <summary>
        /// Log info event with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Info(int eventId, string format, Exception exception, params object[] args);
        #endregion

        #region Warn

        /// <summary>
        /// Log warn.
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message);

        /// <summary>
        /// Log warn with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Log warn exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// Log warn exception with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Warn(string format, Exception exception, params object[] args);

        /// <summary>
        /// Log warn event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        void Warn(int eventId, object message);

        /// <summary>
        /// Log warn event with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Warn(int eventId, string format, params object[] args);

        /// <summary>
        /// Log warn event and exception.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Warn(int eventId, object message, Exception exception);

        /// <summary>
        /// Log warn event and exception with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Warn(int eventId, string format, Exception exception, params object[] args);
        #endregion

        #region Error

        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="message"></param>
        void Error(object message);

        /// <summary>
        /// Log error with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Log error exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(object message, Exception exception);

        /// <summary>
        /// Log error exception with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Error(string format, Exception exception, params object[] args);

        /// <summary>
        /// Log error event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        void Error(int eventId, object message);

        /// <summary>
        /// Log error event with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Error(int eventId, string format, params object[] args);

        /// <summary>
        /// Log error event and exception.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(int eventId, object message, Exception exception);

        /// <summary>
        /// Log error event and exception with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Error(int eventId, string format, Exception exception, params object[] args);
        #endregion

        #region Fatal

        /// <summary>
        /// Log fatal error.
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message);

        /// <summary>
        /// Log fatal error with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Fatal(string format, params object[] args);

        /// <summary>
        /// Log fatal error exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// Log fatal error exception with string format template and variable string args.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Fatal(string format, Exception exception, params object[] args);

        /// <summary>
        /// Log fatal error event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        void Fatal(int eventId, object message);

        /// <summary>
        /// Log fatal error event with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Fatal(int eventId, string format, params object[] args);

        /// <summary>
        /// Log fatal error event and exception.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Fatal(int eventId, object message, Exception exception);

        /// <summary>
        /// Log fatal error event and exception with string format template and variable string args.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Fatal(int eventId, string format, Exception exception, params object[] args);
        #endregion
    }
}
