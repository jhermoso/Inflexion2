//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// Generates loggers used for testing Inflexion2.Logging
    /// </summary>
    public class TestLoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger(Type type)
        {
            return this.GetLogger(type.FullName);
        }

        public ILogger GetLogger(string name)
        {
            return new TestLogger();
        }
    }
}
