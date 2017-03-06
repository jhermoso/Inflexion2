// --------------------------------------------------------------------------
// <copyright file="ApplicationErrorHandler.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;


    using Inflexion2.Resources;
    using Inflexion2.Infrastructure;
    using Inflexion2.Logging;

    /// <summary>
    /// Clase pública sellada encargada de la gestión de errores para la
    /// fachada remota WCF.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public class ApplicationErrorHandler : IErrorHandler
    {
        #region Methods

        /// <summary>
        /// Permite errores de procesamiento y devuelve un valor que indica si
        /// el transportador del envío cancela la sesión y el contexto de la
        /// instancia en ciertos casos.
        /// </summary>
        /// <remarks>
        /// Traza el error y lo maneja.
        /// </remarks>
        /// <param name="exception">
        /// Parámetro de tipo <see cref="System.Exception"/> que representa la
        /// excepción lanzada durante el proceso.
        /// </param>
        /// <returns>
        /// Devuelve <c>true</c> si  o debería abortar la sesión y
        /// el contexto de la instancia si no es de tipo
        /// System.ServiceModel.InstanceContextMode.Single;
        /// de lo contrario devuelve <c>false</c>.
        /// </returns>
        public bool HandleError(Exception exception)
        {
            if (exception != null)
            {
                // Escribimos en el log.
                //ManagerIoC.Container.Resolve<ILoggerFactory>().Create(this.GetType()).Fatal(Messages.error_ErrorNoManejado, exception);
            }
            // Indicamos que el error ha sido gestionado.
            return true;
        }

        /// <summary>
        /// Método que encargado de la creación de <see cref="System.ServiceModel.FaultException"/>
        /// personalizadas que será devuelta como una excepción en la ejecución de un método de un servicio.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="exception">
        /// Parámetro de tipo <see cref="System.Exception"/> lanzada en la ejecución de un
        /// método de un servicio.
        /// </param>
        /// <param name="version">
        /// Parámetro que indica la versión SOAP del mensaje.
        /// </param>
        /// <param name="message">
        /// Parámetro de tipo <see cref="System.ServiceModel.Channels.Message" />
        /// que es devuelto al cliente.
        /// </param>
        public virtual void ProvideFault(
            Exception exception,
            MessageVersion version,
            ref Message message)
        {
            FaultException fault = exception as FaultException;
            if (fault == null)
            {
                if (exception is Inflexion2.Domain.Validation.ValidationException)
                {
                    fault = FaultObject.Create<ValidationException>(new ValidationException(exception as Inflexion2.Domain.Validation.ValidationException));
                }
                else
                {
                    fault = FaultObject.Create<InternalException>(new InternalException(exception));
                }
            }

            message = Message.CreateMessage(version, fault.CreateMessageFault(), fault.Action);
        }

        #endregion Methods
    }
}