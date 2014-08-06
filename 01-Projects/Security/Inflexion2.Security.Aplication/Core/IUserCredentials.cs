// -----------------------------------------------------------------------
// <copyright file="IUserCredentials.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.Core
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Interfaz utilizada para las credenciales del usuario.
    /// </summary>
    /// <remarks>
    /// Sin comentarios especiales.
    /// </remarks>
    public interface IUserCredentials<TIdentifier> : Inflexion2.Application.DataTransfer.Core.IDataTransferObject

    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece el nombre de dominio
        /// al que pertenece el usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre del
        /// dominio al que pertenece el usuario.
        /// </value>
        string Domain
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece la password del usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establece la
        /// password del usuario.
        /// </value>
        string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el nombre de usuario,
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre del usuario.
        /// </value>
        string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        TIdentifier ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        string ApplicationVersion
        {
            get;
            set;
        }

        #endregion Properties
    }
}