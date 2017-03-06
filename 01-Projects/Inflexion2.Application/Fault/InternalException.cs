// -----------------------------------------------------------------------
// <copyright file="InternalException.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Clase de excepción interna para el Fault.
    /// </summary>

    [DataContract(Namespace = "")]
    public class InternalException : FaultObject
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:InternalException"/> con el
        /// mensaje de error especificado.
        /// </summary>
        /// <param name="message">
        /// Parámetro que indica el mensaje de la excepción.
        /// </param>
        public InternalException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:InternalException"/> con el
        /// la excepción especificada.
        /// </summary>
        /// <param name="exception">
        /// Parámetro de tipo <see cref="Exception"/> que indica la excepción producida.
        /// </param>
        public InternalException(Exception exception)
        : base(exception)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:InternalException"/> con el
        /// mensaje de error especificado y la excepción interna.
        /// </summary>
        /// <param name="message">
        /// Parámetro que indica el mensaje de la excepción.
        /// </param>
        /// <param name="innerException">
        /// Parámetro de tipo <see cref="Exception"/> que identifica la excepción interna.
        /// </param>
        public InternalException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        #endregion Constructors
    }

    /// <summary>
    /// Validation exception
    /// </summary>
    [DataContract(Namespace = "")]
    public class ValidationException : InternalException
    {
        #region Constructors

        /// <summary>
        /// constructs and gets the message for a validation exception
        /// </summary>
        /// <param name="validationException"></param>
        public ValidationException(Inflexion2.Domain.Validation.ValidationException validationException)
        : base(validationException.Message)
        {
            this.ValidationErrors = validationException.ValidationErrors.Select(e => e.Message).ToList();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// .en collection of errors messages
        /// </summary>
        [DataMember]
        public IEnumerable<string> ValidationErrors
        {
            get;
            private set;
        }

        #endregion Properties
    }
}