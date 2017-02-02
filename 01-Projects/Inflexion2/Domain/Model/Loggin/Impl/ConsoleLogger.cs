//----------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// logger implementation for console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private const string layout = "{0} - {1} - {2} - {3}";

        private string type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public ConsoleLogger(Type type)
        {
            this.type = type.FullName;
        }

        /// <summary>
        /// <see cref="ILogger.Debug(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            this.WriteToConsole("DEBUG", message);
        }

        /// <summary>
        /// <see cref="ILogger.Debug(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception)
        {
            this.WriteToConsole("DEBUG", message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.DebugFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
            this.WriteToConsole("DEBUG", format, args);
        }

        /// <summary>
        /// <see cref="ILogger.DebugFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.WriteToConsole("DEBUG", provider, format, args);
        }

        /// <summary>
        /// <see cref="ILogger.Error(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            this.WriteToConsole("ERROR", message);
        }

        /// <summary>
        /// <see cref="ILogger.Error(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
            this.WriteToConsole("ERROR", message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.ErrorFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
            this.WriteToConsole("ERROR", format, args);
        }

        /// <summary>
        /// <see cref="ILogger.ErrorFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.WriteToConsole("ERROR", provider, format, args);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            this.WriteToConsole("FATAL", message);
        }

        /// <summary>
        /// <see cref="ILogger.Fatal(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception)
        {
            this.WriteToConsole("FATAL", message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.FatalFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args)
        {
            this.WriteToConsole("FATAL", format, args);
        }

        /// <summary>
        /// <see cref="ILogger.InfoFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.WriteToConsole("FATAL", provider, format, args);
        }

        /// <summary>
        /// <see cref="ILogger.Info(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            this.WriteToConsole("INFO", message);
        }

        /// <summary>
        /// <see cref="ILogger.Info(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception)
        {
            this.WriteToConsole("INFO", message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.InfoFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            this.WriteToConsole("INFO", format, args);
        }

        /// <summary>
        /// <see cref="ILogger.InfoFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.WriteToConsole("INFO", provider, format, args);
        }

        /// <summary>
        /// <see cref="ILogger.Warn(object)"/>
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            this.WriteToConsole("WARNING", message);
        }


        /// <summary>
        /// <see cref="ILogger.Warn(object, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception)
        {
            this.WriteToConsole("WARNING", message, exception);
        }

        /// <summary>
        /// <see cref="ILogger.WarnFormat(string, object[])"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
            this.WriteToConsole("WARNING", format, args);
        }

        /// <summary>
        /// <see cref="ILogger.WarnFormat(IFormatProvider, string, object[])"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.WriteToConsole("WARNING", provider, format, args);
        }

        private static string CurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
        }

        private void WriteToConsole(string level, object message)
        {
            Console.WriteLine(string.Format(layout, CurrentDateTime(), level, this.type, message));
        }

        private void WriteToConsole(string level, object message, Exception exception)
        {
            Console.WriteLine(string.Format(layout, CurrentDateTime(), level, this.type, string.Format("{0} Exception: {1}", message, exception.ToString())));
        }

        private void WriteToConsole(string level, string format, params object[] args)
        {
            Console.WriteLine(string.Format(layout, CurrentDateTime(), level, this.type, string.Format(format, args)));
        }

        private void WriteToConsole(string level, IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(string.Format(layout, CurrentDateTime(), level, this.type, string.Format(provider, format, args)));
        }
    }
}