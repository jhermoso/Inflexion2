// ---------------------------------------------------------------------------------
// <copyright file="ApplicationErrorHandlerAttribute.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// Clase pública sellada encargada de indicar el comportamiento del
    /// servicio permitiendo agregar el DefaultErrorHandler a todos los
    /// servicios WCF.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ApplicationErrorHandlerAttribute : Attribute, IServiceBehavior
    {
        #region Fields

        readonly Type errorHandlerType;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationErrorHandlerAttribute"/> class.
        /// </summary>
        public ApplicationErrorHandlerAttribute()
        {
            this.errorHandlerType = typeof(ApplicationErrorHandler);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationErrorHandlerAttribute"/> class.
        /// </summary>
        /// <param name="handlerType">The handler.</param>
        public ApplicationErrorHandlerAttribute(Type handlerType)
        {
            this.errorHandlerType = handlerType;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que ofrece la posibilidad de pasar datos personalizados para
        /// los elementos de enlace para apoyar la ejecución del contrato.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="serviceDescription">
        /// Parámetro que indica la descripción del servicio.
        /// </param>
        /// <param name="serviceHostBase">
        /// Parámetro que indica el host que está siendo construido.
        /// </param>
        /// <param name="endpoints">
        /// Parámetro que indica la colección de endponits de los servicios.
        /// </param>
        /// <param name="bindingParameters">
        /// Parámetro que indica la colección de objetos personalizados
        /// a los que los elementos de enlace tienen acceso.
        /// </param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            // No aplica.
        }

        /// <summary>
        /// Método encargado de cambiar valores de propiedades o insertar extensiones de objetos
        /// tales como gestores de errores, mensajes, en tiempo de ejecución.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="serviceDescription">
        /// Parámetro que indica la descripción del servicio.
        /// </param>
        /// <param name="serviceHostBase">
        /// Parámetro que indica el host que está siendo construido.
        /// </param>
        public void ApplyDispatchBehavior(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
            if (serviceHostBase != null && serviceHostBase.ChannelDispatchers.Any())
            {
                // Añadimos el manipulador de errores por defecto a los dispatcher en WCF.
                foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
                {
                    dispatcher.ErrorHandlers.Add((IErrorHandler)Activator.CreateInstance(errorHandlerType));
                }
            }
        }

        /// <summary>
        /// Método que ofrece la posibilidad de inspeccionar el service host y
        /// la descripción del servicio para confirmar que el servicio puede
        /// ejecutarse correctamente.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="serviceDescription">
        /// Parámetro que indica la descripción del servicio.
        /// </param>
        /// <param name="serviceHostBase">
        /// Parámetro que indica el host que está siendo construido.
        /// </param>
        public void Validate(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
            // No aplica.
        }

        #endregion Methods
    }
}