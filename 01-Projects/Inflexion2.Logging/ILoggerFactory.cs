//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// Factory methods for obtaining instances of <see cref="ILogger"/> adapters
    /// </summary>
    public interface ILoggerFactory
    {
        ILogger GetLogger(Type type);
        ILogger GetLogger(string name);
    }
}
