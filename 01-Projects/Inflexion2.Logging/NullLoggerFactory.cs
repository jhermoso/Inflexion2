//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// Default <see cref="ILoggerFactory"/> implementation that returns <see cref="NullLogger"/> 
    /// instances that silently drop all log entries
    /// 
    /// This factory is used if configuration is incomplete or invalid
    /// </summary>
    public class NullLoggerFactory : ILoggerFactory
    {
        /// <summary>Singleton, to keep null logger as lightweight as possible</summary>
        private static readonly NullLogger instance = new NullLogger();

        public ILogger GetLogger(Type type)
        {
            return instance;
        }

        public ILogger GetLogger(string name)
        {
            return instance;
        }
    }
}
