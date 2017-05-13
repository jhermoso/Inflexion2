//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// ILogger abstract basic common implementation for end adapted implementations.
    /// this class avoid to fully implement every adapter, for example the null logger <see cref="NullLogger"/>
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        /// <summary>
        /// <see cref="ILogger.Log(LogEntry)"/>
        /// </summary>
        /// <param name="entry"></param>
        public abstract void Log(LogEntry entry);

        private void LogInternal(LogLevel level, object message = null, 
            Exception exception = null, int? eventId = null)
        {
            var entry = new LogEntry()
            {
                LogLevel = level, 
                Message = message != null ? message.ToString() : String.Empty, 
                Exception = exception,
                EventId = eventId
            };

            this.Log(entry);
        }

        #region Trace
        /// <summary>
        /// <see cref="ILogger.Trace(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Trace(object message)
        {
            this.LogInternal(LogLevel.Trace, message);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Trace(string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Trace, message);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Trace(object message, Exception exception)
        {
            this.LogInternal(LogLevel.Trace, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Trace(string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Trace, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(int, object)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        public virtual void Trace(int eventId, object message)
        {
            this.LogInternal(LogLevel.Trace, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Trace(int eventId, string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Trace, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Trace(int eventId, object message, Exception exception)
        {
            this.LogInternal(LogLevel.Trace, message, exception, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Trace(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Trace(int eventId, string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Trace, message, exception, eventId);
        }
        #endregion

        #region Debug

        /// <summary>
        /// <see cref="ILogger.Debug(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            this.LogInternal(LogLevel.Debug, message);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Debug(string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Debug, message);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Debug(object message, Exception exception)
        {
            this.LogInternal(LogLevel.Debug, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Debug(string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Debug, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Error(int, object)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        public virtual void Debug(int eventId, object message)
        {
            this.LogInternal(LogLevel.Debug, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(int, string, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Debug(int eventId, string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Debug, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(int, string, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Debug(int eventId, object message, Exception exception)
        {
            this.LogInternal(LogLevel.Debug, message, exception, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Debug(int eventId, string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Debug, message, exception, eventId);
        }
        #endregion

        #region Info
        /// <summary>
        /// <see cref="ILogger.Info(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            this.LogInternal(LogLevel.Info, message);
        }

        /// <summary>
        /// <see cref="ILogger.Info(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Info(string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Info, message);
        }

        /// <summary>
        /// <see cref="ILogger.Info(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Info(object message, Exception exception)
        {
            this.LogInternal(LogLevel.Info, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Info(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Info(string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Info, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Info(int, object)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        public virtual void Info(int eventId, object message)
        {
            this.LogInternal(LogLevel.Info, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Info(int, string, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Info(int eventId, string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Info, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Info(int, object, Exception)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Info(int eventId, object message, Exception exception)
        {
            this.LogInternal(LogLevel.Info, message, exception, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Info(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Info(int eventId, string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Info, message, exception, eventId);
        }
        #endregion

        #region Warn

        /// <summary>
        /// <see cref="ILogger.Warn(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            this.LogInternal(LogLevel.Warn, message);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Warn(string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Warn, message);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Warn(object message, Exception exception)
        {
            this.LogInternal(LogLevel.Warn, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Warn(string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Warn, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(int, object)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        public virtual void Warn(int eventId, object message)
        {
            this.LogInternal(LogLevel.Warn, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(int, string, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Warn(int eventId, string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Warn, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(int, object, Exception)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Warn(int eventId, object message, Exception exception)
        {
            this.LogInternal(LogLevel.Warn, message, exception, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Warn(int eventId, string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Warn, message, exception, eventId);
        }
        #endregion

        #region Error

        /// <summary>
        /// <see cref="ILogger.Error(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            this.LogInternal(LogLevel.Error, message);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Error(string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Error, message);
        }

        /// <summary>
        /// <see cref="ILogger.Error(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Error(object message, Exception exception)
        {
            this.LogInternal(LogLevel.Error, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Error(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Error(string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Error, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, object)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        public virtual void Error(int eventId, object message)
        {
            this.LogInternal(LogLevel.Error, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, string, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Error(int eventId, string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Error, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, object, Exception)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Error(int eventId, object message, Exception exception)
        {
            this.LogInternal(LogLevel.Error, message, exception, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Error(int eventId, string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Error, message, exception, eventId);
        }
        #endregion

        #region Fatal

        /// <summary>
        /// <see cref="ILogger.Fatal(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            this.LogInternal(LogLevel.Fatal, message);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Fatal(string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Fatal, message);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Fatal(object message, Exception exception)
        {
            this.LogInternal(LogLevel.Fatal, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(string, Exception, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Fatal(string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Fatal, message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.Info(int, object)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        public virtual void Fatal(int eventId, object message)
        {
            this.LogInternal(LogLevel.Fatal, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, string, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public virtual void Fatal(int eventId, string format, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Fatal, message, null, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, object, Exception)"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Fatal(int eventId, object message, Exception exception)
        {
            this.LogInternal(LogLevel.Fatal, message, exception, eventId);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(int, string, Exception, object[])"/>
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="format"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public virtual void Fatal(int eventId, string format, Exception exception, params object[] args)
        {
            var message = String.Format(format, args);
            this.LogInternal(LogLevel.Fatal, message, exception, eventId);
        }
        #endregion
    }
}
