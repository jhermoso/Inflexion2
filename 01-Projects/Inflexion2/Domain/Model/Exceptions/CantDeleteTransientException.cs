//----------------------------------------------------------------------------------------------
// <copyright file="AggregateNotFoundException.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2
{
    using System;
    /// <summary>
    /// Try to delete a transient entity Exception
    /// </summary>
    [Serializable]
    public class CantDeleteTransientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CantDeleteTransientException"/> class.
        /// </summary>
        public CantDeleteTransientException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CantDeleteTransientException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CantDeleteTransientException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CantDeleteTransientException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public CantDeleteTransientException(string message, Exception inner)
        : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CantDeleteTransientException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected CantDeleteTransientException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        : base(info, context)
        {
        }
    }
}