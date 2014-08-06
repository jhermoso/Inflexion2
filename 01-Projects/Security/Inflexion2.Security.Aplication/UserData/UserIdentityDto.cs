//-----------------------------------------------------------------------
// <copyright file="UserIdentityDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Inflexion2.Security.Application.UserData
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Clase que corresponde con el dominio de UserIdentity del contexto de seguridad.
    /// </summary>
    /// <remarks>
    /// Dto de la clase UserIdentity.
    /// </remarks>
    [DataContract]
    //[KnownType(typeof(CreateUserIdentityDto<TIdentifier>))]
    public class UserIdentityDto<TIdentifier> : Inflexion2.Application.DataTransfer.Base.BaseEntityDataTransferObject<TIdentifier>
            where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:UserIdentityDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        public UserIdentityDto()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad que obtiene o establece la dirección de email.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para la dirección de email.
        /// </value>
        [DataMember]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el nombre completo del usuario
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para el nombre completo del usuario.
        /// </value>
        [DataMember]
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que indica si el usuario está bloqueado.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor para indicar si el usuario está bloqueado.
        /// </value>
        [DataMember]
        public bool IsLdapAuthenticationRequired
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que indica si el usuario está bloqueado.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor para indicar si el usuario está bloqueado.
        /// </value>
        [DataMember]
        public bool IsLocked
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece el identificador de la
        /// configuración de password para el usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la configuración
        /// del usuario.
        /// </value>
        [DataMember]
        public TIdentifier PasswordConfigurationId
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el nombre de usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor utilizado para el nombre de usuario.
        /// </value>
        [DataMember]
        public string UserName
        {
            get;
            set;
        }

        #endregion Properties
    }

    [DataContract]
    public sealed class CreateUserIdentityDto<TIdentifier> : UserIdentityDto<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        [DataMember]
        public string Password
        {
            get;
            set;
        }

        [DataMember]
        public string Salt
        {
            get;
            set;
        }
    }
}