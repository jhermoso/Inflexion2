//----------------------------------------------------------------------------------------------
// <copyright file="LoggerManager.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Logging
{
    using System;

    /// <summary>
    /// Empty logger implementation for testing 
    /// this implementation is independent of any technology selected
    /// </summary>
    public static class LoggerManager
    {
        /// <summary>
        ///this an exampl how to inject the implementation of ILogger
        /// </summary>
        public static Func<Type, ILogger> GetLogger = type => new EmptyLogger();
    }
}