//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging.Log4Net
{
    using System;
    using log4net.Config;
    using Inflexion2.Logging;
    using Log4NetManager = log4net.LogManager;

    /// <summary>
    /// Generates log4net logging adapters
    /// </summary>
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// Initialises log4net from config file
        /// </summary>
        public Log4NetLoggerFactory()
        {
            XmlConfigurator.Configure();
        }

        public ILogger GetLogger(Type type)
        {
            return this.GetLogger(type.FullName);
        }

        public ILogger GetLogger(string name)
        {
            return new Log4NetLogger(Log4NetManager.GetLogger(name));
        }
    }
}
