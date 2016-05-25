// -----------------------------------------------------------------------
// <copyright file="ApplicationContext.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion.Framework.UX.Windows
{

    using System;
    using System.Runtime.Remoting.Messaging;
    using System.ServiceModel;
    using Inflexion.Framework.Application.Security.Data.Base;


    /// <summary>
    /// Clase estática que representa el contexto de la aplicación para la parte cliente.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public static class ApplicationContext
    {

        #region FIELDS

            /// <summary>
            /// Variable privada estática para almacenar la clave utilizada 
            /// para guardar en los diferentes contextos.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            private static UserContextDto context;

        #endregion

        #region PROPERTIES

            /// <summary>
            /// Propiedad pública que obtiene o establece el contexto del usuario.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <value>
            /// Valor que es utilizado para obtener o establecer el contexto del usuario.
            /// </value>
            public static UserContextDto UserContext
            {
                get
                {
                    // Devolvemos el contexto.
                    return context;
                }
                set
                {
                    // Añadimos el contexto creado a la colección.
                    context = value;
                }
            } // UserContextDto

        #endregion

    } // ApplicationContext

} // Inflexion.Framework.UX.Windows
