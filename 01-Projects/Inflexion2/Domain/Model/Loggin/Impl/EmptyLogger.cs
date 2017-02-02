//----------------------------------------------------------------------------------------------
// <copyright file="EmptyLogger.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// mplementation of ILoggerFacade that does nothing. 
    /// This implementation is useful when the application does 
    /// not need logging but there are infrastructure pieces that assume there is a logger.
    /// https://msdn.microsoft.com/en-us/library/microsoft.practices.prism.logging.emptylogger(v=pandp.50).aspx
    /// </summary>
    public class EmptyLogger : ILogger
    {
        /// <summary>
        /// <see cref="ILogger.Debug(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Debug(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception)
        {
        }

        /// <summary>
        /// <see cref="ILogger.DebugFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.DebugFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Error(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Error(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
        }

        /// <summary>
        /// <see cref="ILogger.ErrorFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.ErrorFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception)
        {
        }

        /// <summary>
        /// <see cref="ILogger.FatalFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.InfoFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Info(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Info(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception)
        {
        }

        /// <summary>
        /// <see cref="ILogger.InfoFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.InfoFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Warn(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
        }

        /// <summary>
        /// <see cref="ILogger.Warn(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception)
        {
        }

        /// <summary>
        /// <see cref="ILogger.WarnFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
        }

        /// <summary>
        /// <see cref="ILogger.WarnFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
        }
    }
}