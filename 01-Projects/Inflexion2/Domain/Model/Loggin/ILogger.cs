//----------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// common logger manager contract for trace instrumentation.
    /// this interface is independent from the end tool selected.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// log debug message
        /// </summary>
        /// <param name="message"></param>
        void Debug(object message);

        /// <summary>
        /// log debug message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// log debug format message 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// log debug format provider message (CultureInfo)
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void DebugFormat(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// log error message
        /// </summary>
        /// <param name="message"></param>
        void Error(object message);

        /// <summary>
        /// log error with message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(object message, Exception exception);

        /// <summary>
        /// log error message with format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// log error with format provider (CultureInfo)
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void ErrorFormat(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// log fatal error message
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message);

        /// <summary>
        /// log fatal error message with exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// log fatal error message with format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        /// log fatal error message with format provider 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void FatalFormat(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// log info message 
        /// </summary>
        /// <param name="message"></param>
        void Info(object message);

        /// <summary>
        /// log info message with exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(object message, Exception exception);

        /// <summary>
        /// log info message with format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// log info message with format provider
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void InfoFormat(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// log warn message
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message);

        /// <summary>
        /// log warn message with exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// log warn message with format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void WarnFormat(string format, params object[] args);

        /// <summary>
        /// log warn message with format provider
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void WarnFormat(IFormatProvider provider, string format, params object[] args);
    }
}