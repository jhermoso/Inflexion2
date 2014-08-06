// -----------------------------------------------------------------------
// <copyright file="UserCredentialsDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.UserData // old Inflexion.Framework.Application.Security.Data.Base
{
    using System;
    using System.Runtime.Serialization;

    using Inflexion2.Security.Application.Core;

    /// <summary>
    /// Clase para almacenar las credenciales del usuario.
    /// </summary>
    /// <remarks>
    /// Dto utilizado para la autenticación del usuario.
    /// </remarks>
    [DataContract]
    //[KnownType(typeof(UserContextDto<TIdentifier>))]
    public class UserCredentialsDto<TIdentifier> : IUserCredentials<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:UserCredentialsDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public UserCredentialsDto()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:UserCredentialsDto"/>.
        /// </summary>
        /// <param name="userName">
        /// Parámetro que indica el nombr de usuario para las credenciales.
        /// </param>
        /// <param name="password">
        /// Parámetro que indica la password del usuario.
        /// </param>
        /// <param name="domain">
        /// Parámetro que indica el nombre del dominio al que pertenece el usuario.
        /// </param>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public UserCredentialsDto(
            string userName,
            string password,
            string domain,
            TIdentifier applicationId,
            string applicationVersion)
        {
            // Inicializamos las propiedades de la clase.
            this.UserName = userName;
            this.Password = password;
            this.Domain = domain;
            this.ApplicationId = applicationId;
            this.ApplicationVersion = applicationVersion;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que obtiene o establece el nombre de dominio
        /// al que pertenece el usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre de
        /// dominio al que pertenece el usuario..
        /// </value>
        [DataMember]
        public string Domain
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la password del usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la password del usuario.
        /// </value>
        [DataMember]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece el nombre del usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre del usuario.
        /// </value>
        [DataMember]
        public string UserName
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
        [DataMember]
        public TIdentifier ApplicationId
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
        [DataMember]
        public string ApplicationVersion
        {
            get;
            set;
        }

        #endregion Properties
    }
}