// -----------------------------------------------------------------------
// <copyright file="UserContextDto.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Security.Application.UserData //old  Inflexion.Framework.Application.Security.Data.Base
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Inflexion2.Security.Application.Core;// old Inflexion.Framework.Application.Security.Data.Core;

    /// <summary>
    /// Clase que corresponde con el dominio UserContext del contexto de seguridad.
    /// </summary>
    /// <remarks>
    /// Dto de la clase UserContext.
    /// </remarks>
    [DataContract]
    public sealed class UserContextDto<TIdentifier> : UserCredentialsDto<TIdentifier>, Inflexion2.Application.DataTransfer.Core.IDataTransferObject 
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:UserContextDto"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public UserContextDto()
        {
            // Inicializamos la lita de Roles.
            this.Roles = new List<RoleDto<TIdentifier>>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Propiedad pública que obtiene o establece indentificador
        /// del contexto.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer indentificador
        /// del contexto.
        /// </value>
        [DataMember]
        public int ContextId
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece el nombre
        /// completo del usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre
        /// completo del usuario.
        /// </value>
        [DataMember]
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece la lista de
        /// roles a los que pertenece el usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer la lista de
        /// roles a los que pertenece el usuario.
        /// </value>
        [DataMember]
        public List<RoleDto<TIdentifier>> Roles
        {
            get;
            set;
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece indentificador
        /// del usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer indentificador
        /// del usuario.
        /// </value>
        [DataMember]
        public int UserId
        {
            get;
            set;
        }

        #endregion Properties
    }
}