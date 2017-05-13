//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging.NetLog
{
    using System;

    /// <summary>
    /// Generates NLog logging adapters
    /// </summary>
    public class NLogLoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger(Type type)
        {
            return this.GetLogger(type.FullName);
        }

        public ILogger GetLogger(string name)
        {
            return new NLogLogger(NLog.LogManager.GetLogger(name));
        }
    }
}
