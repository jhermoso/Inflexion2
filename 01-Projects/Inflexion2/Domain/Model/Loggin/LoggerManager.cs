//----------------------------------------------------------------------------------------------
// <copyright file="LoggerManager.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// inyect an empty logger
    /// </summary>
    public static class LoggerManager
    {
        /// <summary>
        /// TODO: update summary
        /// </summary>
        public static Func<Type, ILogger> GetLogger = type => new EmptyLogger();
    }
}