// ----------------------------------------------------------------------
// <copyright file="FaultObject.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace Inflexion2.UX.WPF.Fault
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    /// <summary>
    /// Clase pública para la captura de excepciones desde los servicios.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    [DataContract(Namespace="")]
    [KnownType(typeof(InternalException))]
    [KnownType(typeof(ValidationException))]
    public class FaultObject
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:FaultObject"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public FaultObject(string reason)
        {
            this.Reason = reason;
            //this.DateException = DateTime.Now;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:FaultObject"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public FaultObject(Exception innerException)
        {
            this.Reason = innerException.Message;
            //this.DateException = DateTime.Now;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:FaultObject"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public FaultObject(
            string reason,
            Exception innerException)
        : this(reason)
        {
            // Inicializamos la excepción.
            this.Reason = reason;
        }

        #endregion Constructors

        #region Enumerations

        /// <summary>
        ///
        /// </summary>
        [DataContract(Namespace = "")]
        public enum FaultCode
        {
            /// <summary>
            ///
            /// </summary>
            [EnumMember]
            Sever = 0
        }

                #endregion Enumerations

        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece el código de la excepción.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el código de la excepción.
        /// </value>
        [DataMember]
        public FaultCode Code
        {
            get;
            private set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece el texto del mensaje de excepción.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el texto del mensaje de excepción.
        /// </value>
        [DataMember]
        public string Reason
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates a WCF SOAP FaultException based on a CAS Exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static FaultException<T> Create<T>(T exception)
        where T : FaultObject
        {
            try
            {
                var fault = new FaultException<T>(exception, new FaultReason(exception.Reason));
                return fault;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Throws the specified exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        public static void Throw<T>(T exception)
        where T : FaultObject
        {
            throw Create<T>(exception);
        }

        #endregion Methods
    }
}